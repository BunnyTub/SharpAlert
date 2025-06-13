using SharpAlert.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using static SharpAlert.IceBearWorker;
using static SharpAlert.MainEntryPoint;
using static SharpAlert.RegexList;

namespace SharpAlert
{
    public class DirectFeedCapture
    {
        public class TCPServerInfo
        {
            public string ServerName { get; set; }
            public string ServerAddress { get; set; }
            public int ServerPort { get; set; }
        }

        public List<TCPServerInfo> servers = new List<TCPServerInfo>();
        private bool Stop = false;
        private bool StopCalled = false;

        public void ServiceStop()
        {
            if (StopCalled)
            {
                throw new Exception("ServiceStop was already called. If you intended to run the service multiple times, please create a new object.");
            }
            StopCalled = true;
            Stop = true;

            for (int i = 0; i < 5; i++)
            {
                if (!Stop) return;
                Thread.Sleep(1000);
            }

            //while (Stop)
            //{
            //    Thread.Sleep(500);
            //}
        }

        public static string Result { get; private set; } = string.Empty;
        public static int Calls { get; private set; } = 0;

        public static readonly List<Thread> CaptureThreads = new List<Thread>();

        /// <summary>
        /// Starts the TCP Feed Capture service in the current thread as a client.
        /// </summary>
        /// <param name="useHTTPS">Use the secure version of Hypertext Transfer Protocol to connect to the target server.</param>
        public void ServiceRun()
        {
            if (Stop) return;

            if (!servers.Any())
            {
                ConsoleExt.WriteLine("[TCP Feed Capture] No servers found.");
                return;
            }

            try
            {
                lock (servers)
                {
                    foreach (var server in servers)
                    {
                        try
                        {
                            Thread thread = new Thread(() =>
                            {
                                while (true)
                                {
                                    try
                                    {
                                        if (AllowThreadRestarts & !Stop)
                                        {
                                            ServiceReceive(server.ServerName, server.ServerAddress, server.ServerPort);
                                            Thread.Sleep(5 * 1000);
                                        }
                                        else
                                        {
                                            Stop = false;
                                            return;
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        ConsoleExt.WriteLine($"[TCP Feed Capture] Exception caught in {server.ServerName}. {ex.Message}");
                                    }

                                    ConsoleExt.WriteLine($"[TCP Feed Capture] The connection was closed for {server.ServerName}.");
                                }

                            });

                            CaptureThreads.Add(thread);
                            thread.Start();
                            Thread.Sleep(1000); // added sleep because we could accidentally get timed out

                            //ConsoleExt.WriteLine($"[TCP Feed Capture] Getting data from URL: {URLPrefix}://{server}");
                            //HttpResponseMessage message = client.GetAsync($"{URLPrefix}://{server}").Result;
                            //message.EnsureSuccessStatusCode();

                            //if (Calls >= 100000) Calls = 0;
                            //Calls++;

                            //Result = message.Content.ReadAsStringAsync().Result;
                            //EnrollAlerts(Result);
                        }
                        catch (Exception ex)
                        {
                            //AllConnectionsSuccessful = false;
                            ConsoleExt.WriteLine($"[TCP Feed Capture] {ex.Message}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ConsoleExt.WriteLine($"[TCP Feed Capture] {ex.Message}");
            }

            while (true)
            {
                //if ((DateTime.UtcNow - LastHeartbeat).TotalMinutes >= 15)
                //{
                //    DiscordWebhook.SendFormattedMessage("No heartbeats have been received for 15+ minutes.\r\n" +
                //        "The capturing service", 16776960);
                //}
                //else if ((DateTime.UtcNow - LastHeartbeat).TotalMinutes >= 10)
                //{
                //    DiscordWebhook.SendFormattedMessage("No heartbeats have been received for 10+ minutes.", 16776960);
                //}

                try
                {
                    int CheckInterval = QuickSettings.Instance.AlertCheckInterval;
                    for (int i = 0; !(i >= CheckInterval);)
                    {
                        if (Stop)
                        {
                            Stop = false;
                            return;
                        }
                        Thread.Sleep(1000);
                        i++;
                    }
                }
                catch (ThreadAbortException)
                {
                    return;
                }
                catch (Exception ex)
                {
                    ConsoleExt.WriteLine($"[TCP Feed Capture] {ex.StackTrace} {ex.Message}");
                }
            }
        }

        public DateTime LastHeartbeat { get; private set; } = DateTime.UtcNow;

        private bool FirstRun = true;



        private void ServiceReceive(string name, string host, int port)
        {
            string delimiter = "</alert>";

            while (true)
            {
                try
                {
                    using (TcpClient tcp = new TcpClient())
                    {
                        tcp.Connect(host, port);
                        NetworkStream stream = tcp.GetStream();
                        stream.ReadTimeout = 300 * 1000;
                        stream.WriteTimeout = 10 * 1000;
                        ConsoleExt.WriteLine($"[TCP Feed Capture] Connected to {name}.");
                        string dataReceived = string.Empty;
                        
                        List<byte> data = new List<byte>();

                        while (true)
                        {
                            while (!stream.DataAvailable)
                            {
                                if (Stop) return;
                                //try
                                //{
                                stream.WriteByte(0);
                                //}
                                //catch (IOException)
                                //{
                                //    return;
                                //}
                                Thread.Sleep(1000);
                            }
                            data.Clear();
                            DateTime now = DateTime.UtcNow;
                            ConsoleExt.WriteLine($"[TCP Feed Capture] Getting data from {name}. TCP -> {host}:{port}");

                            while (stream.DataAvailable)
                            {
                                int bit = stream.ReadByte();
                                if (bit != -1)
                                {
                                    data.Add((byte)bit);
                                }
                            }

                            ConsoleExt.WriteLine($"[TCP Feed Capture] Processing data from {name}.");
                            string chunk = Encoding.UTF8.GetString(data.ToArray(), 0, data.Count);

                            dataReceived += chunk;

                            // dataReceived.StartsWith("<?xml version='1.0' encoding='UTF-8' standalone='no'?>")

                            if (chunk.Contains(delimiter))
                            {
                                dataReceived = dataReceived.Substring(0, dataReceived.IndexOf(delimiter)) + delimiter;

                                string capturedSent = SentRegex.MatchOrDefault(dataReceived);
                                string capturedStatus = StatusRegex.MatchOrDefault(dataReceived);
                                string capturedSender = SenderRegex.MatchOrDefault(dataReceived);
                                string capturedIdent = IdentifierRegex.MatchOrDefault(dataReceived);
                                string naadsFilename = $"{capturedSent}I{capturedIdent}";

                                if (capturedStatus.ToLowerInvariant() == "system" & capturedSender.ToLowerInvariant().Contains("naads-heartbeat"))
                                {
                                    ConsoleExt.WriteLine($"[TCP Feed Capture] Heartbeat detected from {name}.");
                                    EnrollNAADSHeartbeat(dataReceived, FirstRun);
                                }
                                else
                                {
                                    ConsoleExt.WriteLine($"[TCP Feed Capture] Alert detected from {name}.");
                                    EnrollAlerts(dataReceived, FirstRun);
                                }

                                FirstRun = false;

                                ConsoleExt.WriteLine($"[TCP Feed Capture] Saved data from {name}. TCP -> {host}:{port}");

                                dataReceived = string.Empty;
                            }
                        }
                    }
                }
                catch (TimeoutException)
                {
                    ConsoleExt.WriteLine($"[TCP Feed Capture] Timed out from {name}.");
                }
                catch (Exception ex)
                {
                    ConsoleExt.WriteLine($"[TCP Feed Capture] Exception caught in {name}. {ex.Message}");
                }
                Thread.Sleep(15 * 1000);
            }
        }

        private readonly object EnrollObject = new object();

        public void EnrollAlerts(string data, bool FirstRunner)
        {
            lock (EnrollObject)
            {
                MatchCollection alertMatches = AlertRegex.Matches(data);
                int alertIndex = 0;

                if (alertMatches != null || alertMatches.Count != 0)
                {
                    foreach (Match alert in alertMatches)
                    {
                        try
                        {
                            alertIndex++;
                            if (alert.Value is null) continue;

                            string filename = IdentifierRegex.MatchOrDefault(alert.Value, CreateMD5(alert.Value));

                            //if (string.IsNullOrWhiteSpace(filename))
                            //{
                            //    ConsoleExt.WriteLine("[TCP Feed Capture] Identifier not found. An MD5 value will be assigned to this alert instead.");
                            //    filename = CreateMD5(alert.Value);
                            //}

                            ConsoleExt.WriteLine($"[TCP Feed Capture] {alertIndex} -> {filename}");
                            string alertReplayValue = alert.Value + "<SharpAlertReplay>false</SharpAlertReplay>";
                            SharpDataItem item = new SharpDataItem(filename, alert.Value);

                            if (FirstRunner && QuickSettings.Instance.discardFirstAlerts)
                            {
                                if (TryAddDataToHistory(item))
                                {
                                    ConsoleExt.WriteLine($"[TCP Feed Capture] Alert {alertIndex} ({filename}) has been discarded (discard any alert on start).");
                                }
                            }
                            else
                            {
                                if (TryAddDataToQueue(item))
                                {
                                    ConsoleExt.WriteLine($"[TCP Feed Capture] Alert {alertIndex} ({filename}) has been saved for processing.");
                                }
                                else
                                {
                                    ConsoleExt.WriteLine($"[TCP Feed Capture] Alert {alertIndex} ({filename}) has been discarded (already in queue or history).");
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            ConsoleExt.WriteLine($"[TCP Feed Capture] Couldn't check the data for alert {alertIndex}. {ex.Message}");
                        }
                    }
                    if (alertIndex != 0)
                    {
                        //ConsoleExt.WriteLine($"[TCP Feed Capture] {alertIndex} alert(s) checked.");
                    }
                    else ConsoleExt.WriteLine($"[TCP Feed Capture] No alerts were checked.");
                }
                else
                {
                    ConsoleExt.WriteLine("[TCP Feed Capture] There are no alerts to enroll.");
                }
            }
        }

        public void EnrollNAADSHeartbeat(string data, bool FirstRunner)
        {
            lock (EnrollObject)
            {
                MatchCollection alertMatches = AlertRegex.Matches(data);
                int alertIndex = 0;

                if (alertMatches != null || alertMatches.Count != 0)
                {
                    foreach (Match alert in alertMatches)
                    {
                        try
                        {
                            alertIndex++;
                            if (alert.Value is null) continue;

                            string filename = IdentifierRegex.MatchOrDefault(alert.Value, CreateMD5(alert.Value));

                            //if (string.IsNullOrWhiteSpace(filename))
                            //{
                            //    ConsoleExt.WriteLine("[TCP Feed Capture] Identifier not found. An MD5 value will be assigned to this alert instead.");
                            //    filename = CreateMD5(alert.Value);
                            //}

                            ConsoleExt.WriteLine($"[TCP Feed Capture] {alertIndex} -> {filename} (NAADS Heartbeat)");
                            SharpDataItem item = new SharpDataItem(filename, alert.Value);

                            //if (FirstRun && QuickSettings.Instance.discardFirstAlerts)
                            //{
                            //    if (TryAddDataToHistory(item))
                            //    {
                            //        ConsoleExt.WriteLine($"[TCP Feed Capture] Alert {alertIndex} ({filename}) has been discarded (discard any alert on start).");
                            //    }
                            //}
                            //else
                            {
                                string references = ReferencesRegex.MatchOrDefault(alert.Value);
                                if (!string.IsNullOrWhiteSpace(references))
                                {
                                    //ConsoleExt.WriteLine(references.Groups[0].Value);
                                    //ConsoleExt.WriteLine(references.Groups[1].Value);
                                    //Check.Heartbeat(references,
                                    //    $"{AssemblyDirectory}\\XMLqueue",
                                    //    $"{AssemblyDirectory}\\XMLhistory");

                                    ConsoleExt.WriteLine($"[TCP Feed Capture] Downloading alerts from heartbeat.");
                                    string[] ReferencesList = references.Split('\x20');
                                    //int FilesMatched = 0;
                                    int Found = 0;

                                    bool HeartbeatFailure = false;

                                    foreach (string reference in ReferencesList)
                                    {
                                        string name = string.Empty;
                                        string[] k = reference.Split(',');
                                        string sentDTFull = k[2].Replace("-", "_").Replace(":", "_").Replace("+", "p");
                                        string sentDT = sentDTFull.Substring(0, 10).Replace("_", "-");
                                        name += sentDTFull;
                                        name += "I" + k[1].Replace("-", "_").Replace(":", "_");
                                        //string filenameShort = sentDTFull.Replace("_", "-");

                                        string PrimaryURL = "capcp1.naad-adna.pelmorex.com";
                                        string SecondaryURL = "capcp2.naad-adna.pelmorex.com";

                                        //if (File.Exists(HistoryFolder + $"\\{filename}.xml"))
                                        //{
                                        //    FilesMatched++;
                                        //    continue;
                                        //}

                                        Found++;
                                        string url1 = $"http://{PrimaryURL}/{sentDT}/{name}.xml";
                                        string url2 = $"http://{SecondaryURL}/{sentDT}/{name}.xml";
                                        string result = string.Empty;

                                        try
                                        {
                                            ConsoleExt.WriteLine($"[TCP Feed Capture] {Found} -> {name} ({url1})");
                                            Task<string> xml = client.GetStringAsync(url1);
                                            xml.Wait();
                                            result = xml.Result;
                                            xml.Dispose();
                                        }
                                        catch (Exception e1)
                                        {
                                            try
                                            {
                                                ConsoleExt.WriteLine($"[TCP Feed Capture] Stage 1 failed. {e1.Message}");
                                                ConsoleExt.WriteLine($"[TCP Feed Capture] {Found} -> {name} ({url2}) (retrying)");
                                                Task<string> xml = client.GetStringAsync(url2);
                                                xml.Wait();
                                                result = xml.Result;
                                                xml.Dispose();
                                            }
                                            catch (Exception e2)
                                            {
                                                ConsoleExt.WriteLine($"[TCP Feed Capture] Stage 2 failed. {e2.Message}");
                                                ConsoleExt.WriteLine($"[TCP Feed Capture] Failed to capture the data.");
                                                HeartbeatFailure = true;
                                            }
                                        }

                                        if (!string.IsNullOrWhiteSpace(result)) EnrollAlerts(result, FirstRunner);
                                    }
                                    
                                    if (!HeartbeatFailure) LastHeartbeat = DateTime.UtcNow;
                                }

                                //if (TryAddDataToQueue(item))
                                //{
                                //    ConsoleExt.WriteLine($"[TCP Feed Capture] Alert {alertIndex} ({filename}) has been saved for processing.");
                                //}
                                //else
                                //{
                                //    ConsoleExt.WriteLine($"[TCP Feed Capture] Alert {alertIndex} ({filename}) has been discarded (already queued or is in history).");
                                //}
                            }
                        }
                        catch (Exception ex)
                        {
                            ConsoleExt.WriteLine($"[TCP Feed Capture] Couldn't check the data for alert {alertIndex}. {ex.Message}");
                        }
                    }
                    if (alertIndex != 0) ConsoleExt.WriteLine($"[TCP Feed Capture] {alertIndex} alert(s) checked.");
                    else ConsoleExt.WriteLine($"[TCP Feed Capture] No alerts were checked.");
                }
                else
                {
                    ConsoleExt.WriteLine("[TCP Feed Capture] There are no alerts to enroll.");
                }
            }
        }

        /// <summary>
        /// Starts the TCP Feed Capture service in the current thread as a server instead of a client.
        /// </summary>
        /// <param name="useHTTPS">Use the secure version of Hypertext Transfer Protocol to connect to the target server.</param>
        //public void ServerServiceRun(bool useHTTPS)
        //{
        //    if (Stop) return;

        //    string URLPrefix = useHTTPS ? "https" : "http";
        //    while (true)
        //    {
        //        try
        //        {
        //            ConsoleExt.WriteLine($"[TCP Feed Capture] Getting data from the server.");
        //            Task<HttpResponseMessage> message = client.GetAsync($"{URLPrefix}://{server}");
        //            if (!message.Wait(10000)) continue;
        //            message.Result.EnsureSuccessStatusCode();

        //            if (Calls > 100000) Calls = 0;
        //            Calls++;

        //            Result = message.Result.Content.ReadAsStringAsync().Result;

        //            ConsoleExt.WriteLine($"[TCP Feed Capture] Grabbed data from the server.");

        //            for (int i = 0; !(i >= 30);)
        //            {
        //                if (Stop)
        //                {
        //                    Stop = false;
        //                    return;
        //                }
        //                Thread.Sleep(1000);
        //                i++;
        //            }
        //        }
        //        catch (SocketException e)
        //        {
        //            ConsoleExt.WriteLine($"[TCP Feed Capture] {e.Message}");
        //            Thread.Sleep(1000);
        //        }
        //        catch (TimeoutException)
        //        {
        //            ConsoleExt.WriteLine($"[TCP Feed Capture] Timed out.");
        //        }
        //        catch (HttpRequestException e)
        //        {
        //            ConsoleExt.WriteLine($"[TCP Feed Capture] {e.StackTrace} {e.Message} {e.Message}");
        //        }
        //        catch (AggregateException e)
        //        {
        //            ConsoleExt.WriteLine($"[TCP Feed Capture] {e.StackTrace} {e.Message}");
        //        }
        //        catch (TaskCanceledException)
        //        {
        //            ConsoleExt.WriteLine("[TCP Feed Capture] The executing task was canceled.");
        //        }
        //        catch (ThreadAbortException)
        //        {
        //        }
        //        catch (Exception e)
        //        {
        //            ConsoleExt.WriteLine($"[TCP Feed Capture] {e.StackTrace} {e.Message}");
        //        }
        //    }
        //}

        public static bool TryAddDataToQueue(SharpDataItem item)
        {
            lock (SharpDataQueue)
            {
                lock (SharpDataHistory)
                {
                    try
                    {
                        if (SharpDataQueue.Any(x => x.Name == item.Name) || SharpDataHistory.Any(x => x.Name == item.Name))
                        {
                            return false;
                        }
                        else
                        {
                            SharpDataQueue.Add(item);
                            return true;
                        }
                    }
                    catch (Exception e)
                    {
                        ConsoleExt.WriteLine($"[TCP Feed Capture] {e.StackTrace} {e.Message}");
                        return false;
                    }
                }
            }
        }

        public static bool TryAddDataToHistory(SharpDataItem item)
        {
            lock (SharpDataQueue)
            {
                lock (SharpDataHistory)
                {
                    try
                    {
                        if (SharpDataQueue.Any(x => x.Name == item.Name) || SharpDataHistory.Any(x => x.Name == item.Name))
                        {
                            return false;
                        }
                        else
                        {
                            SharpDataHistory.Add(item);
                            return true;
                        }
                    }
                    catch (Exception e)
                    {
                        ConsoleExt.WriteLine($"[TCP Feed Capture] {e.StackTrace} {e.Message}");
                        return false;
                    }
                }
            }
        }
    }
}
