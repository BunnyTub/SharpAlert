using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
                    Console.Title = $"SharpAlert Console Window - CPU usage: {Math.Floor(GetUsageOfCPUAsPercent())}%";
                    Thread.Sleep(500);
                }
            });

            while (true)
            {
                //while ((chr = reader.Read()) != -1)
                //{
                //    char c = (char)chr;
                //    Console.WriteLine($"[Ice Bear] Read character: {c}");
                //}
                if (Console.ReadKey(true).Key == ConsoleKey.Escape)
                {
                    lock (WriteLock)
                    {
                        Console.WriteLine("Logging has been locked.");
                        Console.WriteLine("Press any key to continue.");
                        Console.ReadKey(true);
                    }
                    //Console.WriteLine("Debug key struck.");
                }
            }
        }

        private static double GetUsageOfCPUAsPercent()
        {
            var startTime = DateTime.UtcNow;
            var startCpuUsage = Process.GetCurrentProcess().TotalProcessorTime;
            Thread.Sleep(500);

            var endTime = DateTime.UtcNow;
            var endCpuUsage = Process.GetCurrentProcess().TotalProcessorTime; var cpuUsedMs = (endCpuUsage - startCpuUsage).TotalMilliseconds;
            var totalMsPassed = (endTime - startTime).TotalMilliseconds; var cpuUsageTotal = cpuUsedMs / (Environment.ProcessorCount * totalMsPassed); return cpuUsageTotal * 100;
        }

        private static readonly object WriteLock = new object();

        public static void WriteLine(object input)
        {
            lock (WriteLock)
            {
                Console.WriteLine(input);
            }
        }
    }
}
