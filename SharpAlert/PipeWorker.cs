using System.IO.Pipes;
using System.IO;
using static SharpAlert.ProgramWorker.MainEntryPoint;
using System.Threading;
using System.Collections.Generic;
using System;

namespace SharpAlert.ProgramWorker
{
    public static class PipeWorker
    {
        public static List<SharpDataItem> SharpDataList = new List<SharpDataItem>();

        public static void ServerServiceRun()
        {
            while (AllowThreadRestarts)
            {
                var server = new NamedPipeServerStream("SharpAlert_EASCulture_AlertIngest");
                
                Console.WriteLine("[Pipe Worker] Waiting for the next connection.");
                server.WaitForConnection();

                Console.WriteLine("[Pipe Worker] Connection attached. Waiting for incoming data.");

                //lock (notify)
                //{
                //    notify.BalloonTipIcon = ToolTipIcon.Info;
                //    notify.BalloonTipTitle = "Attached";
                //    notify.BalloonTipText = "Connected to an app locally on your machine.";
                //    notify.ShowBalloonTip(5000);
                //}

                using (var reader = new StreamReader(server))
                {
                    while (server.IsConnected)
                    {
                        while (reader.EndOfStream)
                        {
                            if (!server.IsConnected) break;
                            Thread.Sleep(50);
                        }
                        string line = reader.ReadLine();
                        if (line == null) break;
                        Console.WriteLine($"[Pipe Worker] Incoming alert text -> {line}");
                        dataproc?.ap?.ProcessExternalAlert("External Alert", "This alert has been relayed from an external source.", line);
                    }
                }

                Console.WriteLine("[Pipe Worker] Connection ended.");
                server.Dispose();
            }
        }

        public static void ClientServiceRun()
        {
        }
    }
}

