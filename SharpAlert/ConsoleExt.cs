using System;
using System.Diagnostics;
using System.Threading;

namespace SharpAlert
{
    internal static class ConsoleExt
    {
        public static void ServiceRun()
        {
            //Stream inputStream = Console.OpenStandardInput();
            //StreamReader reader = new StreamReader(inputStream);
            //int chr;
            ThreadDrool.StartAndForget(() =>
            {
                while (true)
                {
                    Console.Title = $"SharpAlert Console Window | CPU: {Math.Floor(GetUsageOfCPUAsPercent())}% - RAM: {Math.Floor(GetUsageOfRAMAsMB())} MB";
                    Thread.Sleep(500);
                }
            });

            while (true)
            {
                //while ((chr = reader.Read()) != -1)
                //{
                //    char c = (char)chr;
                //    Console.WriteLine($"[Haida] Read character: {c}");
                //}
                if (Console.ReadKey(true).Key == ConsoleKey.Escape)
                {
                    lock (WriteLock)
                    {
                        Console.WriteLine("[Console Extensions] Logging has been locked.");
                        Console.WriteLine("[Console Extensions] Press any key to continue.");
                        Console.ReadKey(true);
                    }
                    //Console.WriteLine("Debug key struck.");
                }
            }
        }

        private static double GetUsageOfCPUAsPercent()
        {
            var startTime = DateTime.UtcNow;
            var startCPU = Process.GetCurrentProcess().TotalProcessorTime;
            Thread.Sleep(500);

            var endTime = DateTime.UtcNow;
            var endCPU = Process.GetCurrentProcess().TotalProcessorTime; var cpuUsedMs = (endCPU - startCPU).TotalMilliseconds;
            var totalMsPassed = (endTime - startTime).TotalMilliseconds; var cpuUsageTotal = cpuUsedMs / (Environment.ProcessorCount * totalMsPassed); return cpuUsageTotal * 100;
        }
        
        private static Process currentproc = null;

        private static double GetUsageOfRAMAsMB()
        {
            if (currentproc == null) currentproc = Process.GetCurrentProcess();
            currentproc.Refresh();
            return currentproc.PrivateMemorySize64 / 1024.0 / 1024.0;
        }

        private static readonly object WriteLock = new object();

        //public static void WriteLine(object input)
        //{
        //    lock (WriteLock)
        //    {
        //        //Console.WriteLine("SERVICE MODE ENABLED --- PERFORMANCE MAY BE IMPACTED --- THIS IS FOR TESTING PURPOSES");
        //        if (ServiceMode) input = $"[Service Mode] {input}";
        //        Console.WriteLine(input);
        //    }
        //}
    }
}


