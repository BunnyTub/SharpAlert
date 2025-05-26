using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Principal;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using SharpAlert.Properties;

namespace SharpAlert
{
    public class HyperServer
    {
        private const string UrlPrefix = "http://localhost:5576/";
        private const string ElevatedUrlPrefix = "http://*:5576/";

        private bool Started = false;
        private bool Stop = false;
        private bool StopCalled = false;

        public void ServiceStop()
        {
            if (!Started) return;
            if (StopCalled)
            {
                throw new Exception("ServiceStop was already called. If you intended to run the service multiple times, please create a new object.");
            }
            StopCalled = true;
            Stop = true;
            while (Stop) Thread.Sleep(100);
        }

        public static bool IsAdministrator => new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);

        public async Task ServiceRun()
        {
            using (var listener = new HttpListener())
            {
                if (IsAdministrator)
                {
                    listener.Prefixes.Add(ElevatedUrlPrefix);
                    Console.WriteLine($"[Hyper Server] Traffic available from any IP: {ElevatedUrlPrefix}");
                }
                else
                {
                    listener.Prefixes.Add(UrlPrefix);
                    Console.WriteLine($"[Hyper Server] Traffic is local only (elevate for any traffic): {UrlPrefix}");
                }

                listener.Start();
                Console.WriteLine($"[Hyper Server] Listening for requests...");
                Console.WriteLine("[Hyper Server] Available endpoints:");

                var methods = GetType().GetMethods();
                foreach (var method in methods)
                {
                    foreach (var attrib in method.GetCustomAttributes())
                    {
                        if (attrib.TypeId.ToString() == "HyperServerMapping")
                        {
                            Console.WriteLine($"[Hyper Server] Endpoint: {UrlPrefix.TrimEnd('/')}/{((Mapping)attrib).Map}");
                        }
                    }
                }

                Started = true;

                while (true)
                {
                    try
                    {
                        var contextTask = listener.GetContextAsync();
                        while (!contextTask.IsCompleted)
                        {
                            if (Stop)
                            {
                                listener.Stop();
                                Stop = false;
                                return;
                            }
                        }

                        var ctx = contextTask.Result;
                        ctx.Response.AddHeader("Access-Control-Allow-Origin", "*");
                        _ = HandleRequestAsync(ctx);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"[Hyper Server] {ex.Message}");
                        await Task.Delay(1000);
                    }
                }
            }
        }

        private async Task HandleRequestAsync(HttpListenerContext ctx)
        {
            try
            {
                string methodName = ctx.Request.Url.Segments.Length > 1
                    ? ctx.Request.Url.Segments[1].TrimEnd('/')
                    : null;

                if (string.IsNullOrEmpty(methodName))
                {
                    await WriteResponseAsync(ctx, 400, "You must specify a method name to call endpoints.");
                    return;
                }

                string[] strParams = ctx.Request.Url
                    .Segments
                    .Skip(2)
                    .Select(s => s.TrimEnd('/'))
                    .ToArray();

                var method = GetType()
                    .GetMethods()
                    .FirstOrDefault(mi => mi.GetCustomAttributes(true)
                    .Any(attr => attr is Mapping m && m.Map == methodName));

                if (method == null)
                {
                    await WriteResponseAsync(ctx, 404, "There is no endpoint at this URL.");
                    return;
                }

                var methodParams = method.GetParameters();
                List<object> paramList = new List<object>();

                if (methodParams.Length > 0 && methodParams[0].ParameterType == typeof(HttpListenerContext))
                    paramList.Add(ctx);

                for (int i = 1; i < methodParams.Length; i++)
                {
                    if (i - 1 < strParams.Length)
                        paramList.Add(Convert.ChangeType(strParams[i - 1], methodParams[i].ParameterType));
                    else
                        paramList.Add(Type.Missing);
                }

                object result = method.Invoke(this, paramList.ToArray());

                if (result != null)
                {
                    if (result is string output)
                    {
                        await WriteResponseAsync(ctx, 200, output);
                        //await WriteResponseAsync(ctx, 200, output, "application/xml");
                        //await WriteResponseAsync(ctx, 200, output, "application/xhtml+xml");
                    }
                    else
                    {
                        await WriteResponseAsync(ctx, 500, "There's something wrong with the endpoint. Try again later.");
                    }
                }
                else if (!ctx.Response.OutputStream.CanWrite)
                {
                }
                else
                {
                    await WriteResponseAsync(ctx, 204, string.Empty); // No Content
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Hyper Server] {ex.Message}");
                await WriteResponseAsync(ctx, 500, "The server encountered a problem while processing the request.");
            }
            finally
            {
                if (ctx.Response.OutputStream.CanWrite)
                    ctx.Response.OutputStream.Close();
                ctx.Response.Close();
            }
        }

        private async Task WriteResponseAsync(HttpListenerContext ctx, int statusCode, string body, string contentType = "text/plain")
        {
            if (ctx.Response.OutputStream != null)
            {
                byte[] buffer = Encoding.UTF8.GetBytes(body);
                ctx.Response.StatusCode = statusCode;
                //ctx.Response.ContentType = contentType;
                ctx.Response.ContentLength64 = buffer.Length;

                await ctx.Response.OutputStream.WriteAsync(buffer, 0, buffer.Length);
            }
        }

        [AttributeUsage(AttributeTargets.Method)]
        public class Mapping : Attribute
        {
            public string Map;
            public Mapping(string s)
            {
                Map = s;
            }

            public override object TypeId
            {
                get { return "HyperServerMapping"; }
            }
        }

        public class AlertInformation
        {
            public bool AlertInProgress { get; set; }
            public string MatchTime { get; set; }
            public string AlertID { get; set; }
            public string AlertType { get; set; }
            public string AlertTitle { get; set; }
            public string AlertText { get; set; }
            //public string AudioFileLocation { get; set; }
        }

        //[Mapping("AlertScroll")]
        //public object AlertScrollPage(HttpListenerContext ctx)
        //{
        //    return File.ReadAllText($"{MainEntryPoint.AssemblyDirectory}\\WebServer\\AlertScroll.html");
        //}

        [Mapping("AlertInfo")]
        public object AlertInfo(HttpListenerContext ctx)
        {
            ctx.Response.ContentType = "application/json";
            if (MainEntryPoint.AlertDisplaying)
            {
                var alert = new AlertInformation
                {
                    AlertInProgress = true,
                    MatchTime = $"{MainEntryPoint.AlertDisplayingBeginTime.Ticks}",
                    AlertID = MainEntryPoint.dataproc?.ap?.DialogAlertID,
                    AlertType = MainEntryPoint.dataproc?.ap?.DialogAlertType,
                    AlertTitle = MainEntryPoint.dataproc?.ap?.DialogAlertTitle,
                    AlertText = $"{MainEntryPoint.dataproc?.ap?.DialogAlertText.Intro} {MainEntryPoint.dataproc?.ap?.DialogAlertText.Body}"
                };

                return JsonSerializer.Serialize(alert);
            }
            else
            {
                var alert = new AlertInformation
                {
                    AlertInProgress = false,
                    AlertID = string.Empty,
                    AlertType = string.Empty,
                    AlertTitle = string.Empty,
                    AlertText = string.Empty
                };

                return JsonSerializer.Serialize(alert);
            }
        }

        [Mapping("AlertXML")]
        public object AlertXML(HttpListenerContext ctx)
        {
            ctx.Response.ContentType = "application/xml";
            string Alerts = "<SharpAlertHyperServer>";
            Alerts += "<SharpAlertNote>When is the dragon update?</SharpAlertNote>";
            Alerts += $"<SharpAlertMaxAlertCount>{Settings.Default.storedMaxSize}</SharpAlertMaxAlertCount>";
            foreach (var alert in MainEntryPoint.SharpDataHistory)
            {
                Alerts += alert.Data + "\r\n";
            }
            Alerts = Alerts.Trim() + "</SharpAlertHyperServer>";
            return Alerts;
        }
        
        [Mapping("AlertXML-Empty")]
        public object Alert(HttpListenerContext ctx)
        {
            ctx.Response.ContentType = "application/xml";
            string Alerts = "<SharpAlertHyperServer>";
            Alerts += "<SharpAlertNote>Purposely returning zero alerts found.</SharpAlertNote>";
            Alerts += $"<SharpAlertMaxAlertCount>{Settings.Default.storedMaxSize}</SharpAlertMaxAlertCount>";
            Alerts += "</SharpAlertHyperServer>";
            return Alerts;
        }

        //[Mapping("WarningSound")]
        //public object WarningSound(HttpListenerContext ctx)
        //{
        //    ctx.Response.ContentType = "application/wav";
        //    ctx.Response.OutputStream.Write();
        //    ctx.Response.OutputStream.Dispose();
        //    return null;
        //}
    }
}
