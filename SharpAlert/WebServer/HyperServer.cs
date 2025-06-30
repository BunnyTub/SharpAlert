using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SharpAlert.Properties;
using static SharpAlert.MainEntryPoint;
using static SharpAlert.IceBearWorker;

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

        public void ServiceRun()
        {
            if (!QuickSettings.Instance.EnableServer) return;

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

                var resources = Assembly.GetExecutingAssembly().GetManifestResourceNames();

                foreach (string resourceName in resources)
                {
                    if (resourceName.StartsWith("SharpAlert.WebServer."))
                    {
                        if (resourceName.ToLowerInvariant().EndsWith(".html") || resourceName.ToLowerInvariant().EndsWith(".htm"))
                        {
                            // Extract just the filename from the full resource name
                            string[] parts = resourceName.Split('.');
                            int count = parts.Length;

                            if (count >= 2)
                            {
                                string fileName = $"{parts[count - 2]}.{parts[count - 1]}";
                                Console.WriteLine($"[Hyper Server] Endpoint (HTML): {UrlPrefix.TrimEnd('/')}/{fileName}");
                            }
                        }
                    
                        if (resourceName.ToLowerInvariant().EndsWith(".css"))
                        {
                            string[] parts = resourceName.Split('.');
                            int count = parts.Length;

                            if (count >= 2)
                            {
                                string fileName = $"{parts[count - 2]}.{parts[count - 1]}";
                                Console.WriteLine($"[Hyper Server] Endpoint (CSS): {UrlPrefix.TrimEnd('/')}/{fileName}");
                            }
                        }
                    
                        if (resourceName.ToLowerInvariant().EndsWith(".js"))
                        {
                            string[] parts = resourceName.Split('.');
                            int count = parts.Length;

                            if (count >= 2)
                            {
                                string fileName = $"{parts[count - 2]}.{parts[count - 1]}";
                                Console.WriteLine($"[Hyper Server] Endpoint (JS): {UrlPrefix.TrimEnd('/')}/{fileName}");
                            }
                        }

                        if (resourceName.ToLowerInvariant().EndsWith(".js"))
                        {
                            string[] parts = resourceName.Split('.');
                            int count = parts.Length;

                            if (count >= 2)
                            {
                                string fileName = $"{parts[count - 2]}.{parts[count - 1]}";
                                Console.WriteLine($"[Hyper Server] Endpoint (JS): {UrlPrefix.TrimEnd('/')}/{fileName}");
                            }
                        }
                    }
                }

                Started = true;

                List<string> BadUserAgents = new List<string>
                {
                    "ByteSpider",
                    "WhenYouFuckingSeeIt727"
                };

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
                            Thread.Sleep(50);
                        }

                        var ctx = contextTask.Result;

                        Console.WriteLine($"[Hyper Server] Request received -> {ctx.Request.RemoteEndPoint.Address}");

                        var userAgent = ctx.Request.UserAgent ?? string.Empty;

                        var match = BadUserAgents.Find(bad =>
                            userAgent.IndexOf(bad, StringComparison.OrdinalIgnoreCase) >= 0);

                        if (match != null)
                        {
                            Console.WriteLine($"[Hyper Server] Returning garbage data. (possible spam/scraper)");
                            Task.Run(() => WriteGarbageResponseAsync(ctx));
                        }
                        else
                        {
                            Task.Run(() => HandleRequestAsync(ctx));
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"[Hyper Server] {ex.Message}");
                        Thread.Sleep(1000);
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

                ctx.Response.AddHeader("Access-Control-Allow-Origin", "*");
                ctx.Response.AddHeader("Cache-Control", "no-cache, no-store, must-revalidate, no-transform");
                ctx.Response.AddHeader($"Warning", "299 SharpAlert \"Unauthorized access or use in administrative areas may violate laws and result in disciplinary action, civil liability, or criminal prosecution. Activity may be monitored and reported. By continuing, you consent to these terms. Stop connection immediately if you are not authorized.\"");

                if (string.IsNullOrEmpty(methodName))
                {
                    await WriteResponseAsync(ctx, 404, "You must specify an endpoint.");
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
                    try
                    {
                        using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("SharpAlert.WebServer." + methodName))
                        {
                            if (stream == null)
                            {
                                await WriteResponseAsync(ctx, 404, $"There is no endpoint at this URL.");
                            }
                            else
                            {
                                using (StreamReader reader = new StreamReader(stream))
                                {
                                    await WriteResponseAsync(ctx, 200, reader.ReadToEnd());
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        await WriteResponseAsync(ctx, 404, $"Could not grab an endpoint at this URL. (why? {ex.Message})");
                    }

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
                    if (result is NullClass) return;
                    
                    if (result is string output)
                    {
                        if (!string.IsNullOrEmpty(output)) await WriteResponseAsync(ctx, 200, output);
                        //await WriteResponseAsync(ctx, 200, output, "application/xml");
                        //await WriteResponseAsync(ctx, 200, output, "application/xhtml+xml");
                    }
                    else
                    {
                        if (result is byte[] byteOutput)
                        {
                            await WriteByteResponseAsync(ctx, 200, byteOutput);
                            //await WriteResponseAsync(ctx, 200, output, "application/xml");
                            //await WriteResponseAsync(ctx, 200, output, "application/xhtml+xml");
                        }
                        else
                        {
                            await WriteResponseAsync(ctx, 500, "There's something wrong with the endpoint. Try again later.");
                        }
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
                Console.WriteLine($"[Hyper Server] {ex.GetBaseException().Message}");
                await WriteResponseAsync(ctx, 500, "The server encountered a problem while processing the request.");
            }
            finally
            {
                if (ctx.Response.OutputStream.CanWrite)
                    ctx.Response.OutputStream.Close();
                ctx.Response.Close();
            }
        }

        // string contentType = "text/plain"
        private async Task WriteResponseAsync(HttpListenerContext ctx, int statusCode, string body)
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

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        private async Task WriteGarbageResponseAsync(HttpListenerContext ctx)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            if (ctx.Response.OutputStream != null)
            {
                ctx.Response.StatusCode = 727;
                ctx.Response.OutputStream.Close();
            }
        }

        private async Task WriteByteResponseAsync(HttpListenerContext ctx, int statusCode, byte[] buffer)
        {
            if (ctx.Response.OutputStream != null)
            {
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

#pragma warning disable IDE0060 // Remove unused parameter

        [Mapping("favicon.ico")]
        public object FavoriteIcon(HttpListenerContext ctx)
        {
            ctx.Response.ContentType = "image/png";

            using (var stream = new MemoryStream())
            {
                Resources.AlertIcon.Save(stream, ImageFormat.Png);
                return stream.ToArray();
            }
        }
        
        [Mapping("version")]
        public object Version(HttpListenerContext ctx)
        {
            return $"</center><h1>SharpAlert v{VersionInfo.MajorVersion}.{VersionInfo.MinorVersion} is hosting this server.</h1></center>";
        }
        
        [Mapping("version-raw")]
        public object VersionRaw(HttpListenerContext ctx)
        {
            return $"{VersionInfo.MajorVersion}.{VersionInfo.MinorVersion}";
        }

        [Mapping("self-destruct")]
        public object SelfDestruct(HttpListenerContext ctx)
        {
            if (AuthenticationFulfilled(ctx))
            {
                byte[] message = Encoding.UTF8.GetBytes("</center><h1>Self-destruct sequence initiated.</h1></center>");
                ctx.Response.OutputStream.Write(message, 0, message.Length);
                ctx.Response.OutputStream.Close();
                Environment.Exit(0);
                return new NullClass();
            }

            return "You cannot just try an initiate a self-destruct sequence without authenticating!";
        }

        //[Mapping("AlertInfo")]
        //public object AlertInfo(HttpListenerContext ctx)
        //{
        //    ctx.Response.ContentType = "application/json";
        //    if (AlertDisplaying)
        //    {
        //        var alert = new AlertInformation
        //        {
        //            AlertInProgress = true,
        //            MatchTime = $"{AlertDisplayingBeginTime.Ticks}",
        //            AlertID = AlertDisplayer.DialogAlertID,
        //            AlertType = AlertDisplayer.DialogAlertType,
        //            AlertTitle = AlertDisplayer.DialogAlertTitle,
        //            AlertText = $"{AlertDisplayer.DialogAlertText.Intro} {AlertDisplayer.DialogAlertText.Body}"
        //        };

        //        return JsonSerializer.Serialize(alert);
        //    }
        //    else
        //    {
        //        var alert = new AlertInformation
        //        {
        //            AlertInProgress = false,
        //            MatchTime = string.Empty,
        //            AlertID = string.Empty,
        //            AlertType = string.Empty,
        //            AlertTitle = string.Empty,
        //            AlertText = string.Empty
        //        };

        //        return JsonSerializer.Serialize(alert);
        //    }
        //}

        private bool AuthenticationFulfilled(HttpListenerContext ctx)
        {
            try
            {
                void SendAuthChallenge(HttpListenerContext ctx_, string message)
                {
                    byte[] buffer = Encoding.UTF8.GetBytes(message);
                    ctx_.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    ctx_.Response.AddHeader("WWW-Authenticate", "Basic realm=\"SharpAlert Administrative Panel\"");
                    ctx_.Response.ContentLength64 = buffer.Length;
                    ctx_.Response.OutputStream.Write(buffer, 0, buffer.Length);
                    ctx_.Response.OutputStream.Close();
                }

                string authHeader = ctx.Request.Headers["Authorization"];

                if (string.IsNullOrWhiteSpace(authHeader) || !authHeader.StartsWith("Basic ", StringComparison.OrdinalIgnoreCase))
                {
                    SendAuthChallenge(ctx, "Please authenticate to use this endpoint.");
                    return false;
                }

                string encodedCredentials = authHeader.Substring("Basic\x20".Length).Trim();
                string decodedCredentials = Encoding.UTF8.GetString(Convert.FromBase64String(encodedCredentials));
                string[] parts = decodedCredentials.Split(':');

                if (parts.Length != 2)
                {
                    ctx.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    return false;
                }

                string username = parts[0];
                string password = parts[1];

                if (username != QuickSettings.Instance.ServerUsername || password != QuickSettings.Instance.ServerPassword)
                {
                    ctx.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    ctx.Response.AddHeader("WWW-Authenticate", "Basic realm=\"SharpAlert Administrative Panel\"");
                    return false;
                }

                ctx.Response.StatusCode = (int)HttpStatusCode.OK;
                return true;
            }
            catch (Exception ex)
            {
                LogFault(ex);
            }

            return true;

            //using (var writer = new StreamWriter(ctx.Response.OutputStream))
            //{
            //    writer.Write("Welcome, admin!");
            //}
        }

        public class NullClass { }

        private readonly string NoAccessMessage = "No authentication, no access. If you're not supposed to be here, stop, and remember that your request is being logged!";

        [Mapping("ClearAlertHistory")]
        public object ClearAlertHistory(HttpListenerContext ctx)
        {
            if (AuthenticationFulfilled(ctx))
            {
                SharpDataHistory.Clear();
                SharpDataRelayedNamesHistory.Clear();
                return "Cleared the alert history.";
            }
            else
            { 
                return NoAccessMessage;
            }
        }
        
        //[Mapping("ClearAlertHistory")]
        //public object Login(HttpListenerContext ctx)
        //{
        //    if (AuthenticationFulfilled(ctx))
        //    {
        //        if (File.Exists(AssemblyDirectory))
        //        {
        //            return "";
        //        }
        //        else
        //        {
        //            return "To use the visual interface, download the optional HTML pack.";
        //        }
        //    }
        //    else
        //    {
        //        return NoAccessMessage;
        //    }
        //}


        [Mapping("AlertXML")]
        public object AlertXML(HttpListenerContext ctx)
        {
            ctx.Response.ContentType = "application/xml";
            string Alerts = "<SharpAlertHyperServer>";
            Alerts += "<SharpAlertNote>When is the bunny update?</SharpAlertNote>";
            Alerts += $"<SharpAlertMaxAlertCount>{QuickSettings.Instance.storedMaxSize}</SharpAlertMaxAlertCount>";
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
            Alerts += $"<SharpAlertMaxAlertCount>{QuickSettings.Instance.storedMaxSize}</SharpAlertMaxAlertCount>";
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
#pragma warning restore IDE0060 // Remove unused parameter
    }
}
