using SharpAlert.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SharpAlert.IceBearWorker;
using static SharpAlert.MainEntryPoint;
using static SharpAlert.RegexList;

namespace SharpAlert
{
    public class DirectFeedCapture
    {
        public class RemoteTCPServer
        {
            public string Address { get; set; }
            public int Port { get; set; }
        }

        public List<RemoteTCPServer> servers = new List<RemoteTCPServer>();
        private bool FirstRun = true;
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

        /// <summary>
        /// Starts the Direct Feed Capture service in the current thread as a client.
        /// </summary>
        /// <param name="useHTTPS">Use the secure version of Hypertext Transfer Protocol to connect to the target server.</param>
        public void ServiceRun()
        {
            if (Stop) return;

            bool LastConnectionSuccessful = true;
            //bool AllConnectionsSuccessful = true;

            try
            {
                lock (servers)
                {
                    foreach (var server in servers)
                    {
                        try
                        {
                            new Thread(() =>
                            {
                                while (true)
                                {
                                    if (AllowThreadRestarts & !Stop)
                                    {
                                        ServiceReceive(server.Address, server.Port);
                                        Thread.Sleep(5 * 1000);
                                    }
                                    else
                                    {
                                        Stop = false;
                                        return;
                                    }

                                    Console.WriteLine($"[Feed Capture | NAADs] Connection closed: {server.Address} on port {server.Port}");
                                }

                            }).Start();
                            //Console.WriteLine($"[Feed Capture | NAADs] Getting data from URL: {URLPrefix}://{server}");
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
                            Console.WriteLine($"[Feed Capture | NAADs] {ex.Message}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Feed Capture | NAADs] {ex.Message}");
            }

            while (true)
            {
                try
                {
                    //if (AllConnectionsSuccessful) Console.WriteLine($"[Feed Capture | NAADs] Fetched from all feeds successfully.");
                    //else Console.WriteLine("[Feed Capture | NAADs] Not all feeds were fetched from successfully.");

                    //if (LastConnectionSuccessful)
                    //{
                    //    lock (notify)
                    //    {
                    //        notify.BalloonTipTitle = "SharpAlert has reconnected";
                    //        notify.BalloonTipText = "Successfully reconnected to the server after an ongoing connection disruption or problem.";
                    //        notify.BalloonTipIcon = ToolTipIcon.Info;
                    //        notify.ShowBalloonTip(5000);
                    //    }
                    //    LastConnectionSuccessful = true;
                    //}
                }
                catch (TimeoutException)
                {
                    Console.WriteLine($"[Feed Capture | NAADs] Timed out.");
                    if (LastConnectionSuccessful)
                    {
                        lock (notify)
                        {
                            notify.BalloonTipTitle = "SharpAlert is having issues";
                            notify.BalloonTipText = "Couldn't connect to the server within a reasonable time. Check your internet connection!";
                            notify.BalloonTipIcon = ToolTipIcon.Warning;
                            notify.ShowBalloonTip(5000);
                        }
                    }
                    Thread.Sleep(30000);
                    LastConnectionSuccessful = false;
                }
                catch (ThreadAbortException)
                {
                    return;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"[Feed Capture | NAADs] {e.Message}");
                    if (e.InnerException != null) Console.WriteLine($"[Feed Capture | NAADs] {e.InnerException.Message}");
                    if (LastConnectionSuccessful)
                    {
                        lock (notify)
                        {
                            notify.BalloonTipTitle = "SharpAlert is having issues";
                            notify.BalloonTipText = "There was an issue when trying to connect to the server. Check your internet connection!";
                            notify.BalloonTipIcon = ToolTipIcon.Warning;
                            notify.ShowBalloonTip(5000);
                        }
                    }
                    LastConnectionSuccessful = false;
                    Thread.Sleep(30000);
                }
                if (FirstRun) FirstRun = false;

                if ((DateTime.UtcNow - LastHeartbeat).TotalMinutes >= 15)
                {
                    DiscordWebhook.SendFormattedMessage("No heartbeats have been received for 15+ minutes.\r\n" +
                        "The capturing service", 16776960);
                }
                else if ((DateTime.UtcNow - LastHeartbeat).TotalMinutes >= 10)
                {
                    DiscordWebhook.SendFormattedMessage("No heartbeats have been received for 10+ minutes.", 16776960);
                }

                try
                {
                    int CheckInterval = Settings.Default.AlertCheckInterval;
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
                catch (Exception e)
                {
                    Console.WriteLine($"[Feed Capture | NAADs] {e.StackTrace} {e.Message}");
                }
            }
        }

        public DateTime LastHeartbeat { get; private set; } = DateTime.UtcNow;

        private void ServiceReceive(string host, int port)
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
                        stream.ReadTimeout = 120 * 1000;
                        stream.WriteTimeout = 10 * 1000;
                        Console.WriteLine($"[{host}:{port}] Connected to the server.");
                        string dataReceived = string.Empty;
                        
                        List<byte> data = new List<byte>();

                        while (true)
                        {
                            while (!stream.DataAvailable)
                            {
                                if (Stop) return;
                                try
                                {
                                    stream.WriteByte(0);
                                }
                                catch (IOException)
                                {
                                    return;
                                }
                                Thread.Sleep(1000);
                            }
                            data.Clear();
                            DateTime now = DateTime.UtcNow;
                            Console.WriteLine($"[{host}:{port}] Processing stream.");

                            while (stream.DataAvailable)
                            {
                                int bit = stream.ReadByte();
                                if (bit != -1)
                                {
                                    data.Add((byte)bit);
                                }
                            }

                            Console.WriteLine($"[{host}:{port}] Stream retrieved. | Size: {data.Count} | Time: {(int)(DateTime.UtcNow - now).TotalMilliseconds}");
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

                                if (capturedStatus.ToLowerInvariant() == "system" & capturedSender.Contains("NAADS-Heartbeat"))
                                {
                                    Console.WriteLine($"[{host}:{port}] Heartbeat detected.");
                                    EnrollHeartbeat(dataReceived);
                                }
                                else
                                {
                                    Console.WriteLine($"[{host}:{port}] Alert detected.");
                                    EnrollAlerts(dataReceived);
                                }

                                Console.WriteLine($"[{host}:{port}] Saved data.");

                                dataReceived = string.Empty;
                            }
                        }
                    }
                }
                catch (TimeoutException)
                {
                    Console.WriteLine($"[{host}:{port}] Timed out.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[{host}:{port}] {ex.Message} {ex.StackTrace}");
                }
                Thread.Sleep(15 * 1000);
            }
        }

        private readonly object EnrollObject = new object();

        public void EnrollAlerts(string data)
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
                            //    Console.WriteLine("[Feed Capture | NAADs] Identifier not found. An MD5 value will be assigned to this alert instead.");
                            //    filename = CreateMD5(alert.Value);
                            //}

                            Console.WriteLine($"[Feed Capture | NAADs] {alertIndex} -> {filename}");
                            string alertReplayValue = alert.Value + "<SharpAlertReplay>false</SharpAlertReplay>";
                            SharpDataItem item = new SharpDataItem(filename, alert.Value);

                            if (FirstRun && Settings.Default.discardFirstAlerts)
                            {
                                if (TryAddDataToHistory(item))
                                {
                                    Console.WriteLine($"[Feed Capture | NAADs] Alert {alertIndex} ({filename}) has been discarded (discard any alert on start).");
                                }
                            }
                            else
                            {
                                if (TryAddDataToQueue(item))
                                {
                                    Console.WriteLine($"[Feed Capture | NAADs] Alert {alertIndex} ({filename}) has been saved for processing.");
                                }
                                else
                                {
                                    Console.WriteLine($"[Feed Capture | NAADs] Alert {alertIndex} ({filename}) has been discarded (already queued or is in history).");
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"[Feed Capture | NAADs] Couldn't check the data for alert {alertIndex}. {ex.Message}");
                        }
                    }
                    if (alertIndex != 0) Console.WriteLine($"[Feed Capture | NAADs] {alertIndex} alert(s) checked.");
                    else Console.WriteLine($"[Feed Capture | NAADs] No alerts were checked.");
                }
                else
                {
                    Console.WriteLine("[Feed Capture | NAADs] There are no alerts to enroll.");
                }
            }
        }

        public void EnrollHeartbeat(string data)
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
                            //    Console.WriteLine("[Feed Capture | NAADs] Identifier not found. An MD5 value will be assigned to this alert instead.");
                            //    filename = CreateMD5(alert.Value);
                            //}

                            Console.WriteLine($"[Feed Capture | NAADs] {alertIndex} -> {filename} (NAADs Heartbeat)");
                            SharpDataItem item = new SharpDataItem(filename, alert.Value);

                            if (FirstRun && Settings.Default.discardFirstAlerts)
                            {
                                if (TryAddDataToHistory(item))
                                {
                                    Console.WriteLine($"[Feed Capture | NAADs] Alert {alertIndex} ({filename}) has been discarded (discard any alert on start).");
                                }
                            }
                            else
                            {
                                string references = ReferencesRegex.MatchOrDefault(alert.Value);
                                if (!string.IsNullOrWhiteSpace(references))
                                {
                                    //Console.WriteLine(references.Groups[0].Value);
                                    //Console.WriteLine(references.Groups[1].Value);
                                    //Check.Heartbeat(references,
                                    //    $"{AssemblyDirectory}\\XMLqueue",
                                    //    $"{AssemblyDirectory}\\XMLhistory");

                                    Console.WriteLine($"[Feed Capture | NAADs] Downloading alerts from heartbeat.");
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
                                            Console.WriteLine($"[Feed Capture | NAADs] {Found} -> {name} ({url1})", ConsoleColor.Yellow);
                                            Task<string> xml = client.GetStringAsync(url1);
                                            xml.Wait();
                                            result = xml.Result;
                                            xml.Dispose();
                                        }
                                        catch (Exception e1)
                                        {
                                            try
                                            {
                                                Console.WriteLine($"[Feed Capture | NAADs] Stage 1 failed. {e1.Message}");
                                                Console.WriteLine($"[Feed Capture | NAADs] {Found} -> {name} ({url2}) (retrying)");
                                                Task<string> xml = client.GetStringAsync(url2);
                                                xml.Wait();
                                                result = xml.Result;
                                                xml.Dispose();
                                            }
                                            catch (Exception e2)
                                            {
                                                Console.WriteLine($"[Feed Capture | NAADs] Stage 2 failed. {e2.Message}", ConsoleColor.Red);
                                                Console.WriteLine($"[Feed Capture | NAADs] Failed to capture the data.", ConsoleColor.Red);
                                                HeartbeatFailure = true;
                                            }
                                        }

                                        if (!string.IsNullOrWhiteSpace(result)) EnrollAlerts(result);
                                    }
                                    
                                    if (!HeartbeatFailure) LastHeartbeat = DateTime.UtcNow;
                                }

                                //if (TryAddDataToQueue(item))
                                //{
                                //    Console.WriteLine($"[Feed Capture | NAADs] Alert {alertIndex} ({filename}) has been saved for processing.");
                                //}
                                //else
                                //{
                                //    Console.WriteLine($"[Feed Capture | NAADs] Alert {alertIndex} ({filename}) has been discarded (already queued or is in history).");
                                //}
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"[Feed Capture | NAADs] Couldn't check the data for alert {alertIndex}. {ex.Message}");
                        }
                    }
                    if (alertIndex != 0) Console.WriteLine($"[Feed Capture | NAADs] {alertIndex} alert(s) checked.");
                    else Console.WriteLine($"[Feed Capture | NAADs] No alerts were checked.");
                }
                else
                {
                    Console.WriteLine("[Feed Capture | NAADs] There are no alerts to enroll.");
                }
            }
        }

        /// <summary>
        /// Starts the Direct Feed Capture service in the current thread as a server instead of a client.
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
        //            Console.WriteLine($"[Feed Capture | NAADs] Getting data from the server.");
        //            Task<HttpResponseMessage> message = client.GetAsync($"{URLPrefix}://{server}");
        //            if (!message.Wait(10000)) continue;
        //            message.Result.EnsureSuccessStatusCode();

        //            if (Calls > 100000) Calls = 0;
        //            Calls++;

        //            Result = message.Result.Content.ReadAsStringAsync().Result;

        //            Console.WriteLine($"[Feed Capture | NAADs] Grabbed data from the server.");

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
        //            Console.WriteLine($"[Feed Capture | NAADs] {e.Message}");
        //            Thread.Sleep(1000);
        //        }
        //        catch (TimeoutException)
        //        {
        //            Console.WriteLine($"[Feed Capture | NAADs] Timed out.");
        //        }
        //        catch (HttpRequestException e)
        //        {
        //            Console.WriteLine($"[Feed Capture | NAADs] {e.StackTrace} {e.Message} {e.Message}");
        //        }
        //        catch (AggregateException e)
        //        {
        //            Console.WriteLine($"[Feed Capture | NAADs] {e.StackTrace} {e.Message}");
        //        }
        //        catch (TaskCanceledException)
        //        {
        //            Console.WriteLine("[Feed Capture | NAADs] The executing task was canceled.");
        //        }
        //        catch (ThreadAbortException)
        //        {
        //        }
        //        catch (Exception e)
        //        {
        //            Console.WriteLine($"[Feed Capture | NAADs] {e.StackTrace} {e.Message}");
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
                        Console.WriteLine($"[Feed Capture | NAADs] {e.StackTrace} {e.Message}");
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
                        Console.WriteLine($"[Feed Capture | NAADs] {e.StackTrace} {e.Message}");
                        return false;
                    }
                }
            }
        }
    }
}
