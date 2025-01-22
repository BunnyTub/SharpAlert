using System;
using System.Threading;
//using static SharpAlert.FeedCapture;
//using static SharpAlert.Program;

namespace SharpAlert
{
    public static class KeyboardProcessor
    {
        private static bool Stop = false;

        public static void ServiceStop()
        {
            Stop = true;
            while (Stop) Thread.Sleep(100);
        }

        public static void ServiceRun()
        {
            throw new NotSupportedException("The Keyboard Processor is no longer available.");

            //while (true)
            //{
            //    if (GetConsoleWindow() != IntPtr.Zero)
            //    {
            //        try
            //        {
            //            switch (Console.ReadKey(true).Key)
            //            {
            //                case ConsoleKey.D0:
            //                    Console.WriteLine("What do you want me to do? Divide by zero?");
            //                    break;
            //                case ConsoleKey.D1:
            //                    Console.WriteLine("--- SharpDataQueue ---");
            //                    foreach (SharpDataItem item in SharpDataQueue)
            //                    {
            //                        Console.WriteLine($"{item.Name}");
            //                    }
            //                    Console.WriteLine("--- SharpDataHistory ---");
            //                    foreach (SharpDataItem item in SharpDataHistory)
            //                    {
            //                        Console.WriteLine($"{item.Name}");
            //                    }
            //                    break;
            //                case ConsoleKey.Delete:
            //                    SharpDataHistory.Clear();
            //                    Console.WriteLine("Cleared history list.");
            //                    break;
            //                case ConsoleKey.O:
            //                    AddFileToQueue();
            //                    break;
            //                case ConsoleKey.F:
                                
            //                    break;
            //                    //case ConsoleKey.G:
            //                    //    Console.WriteLine("GUI shown.");
            //                    //    break;
            //            }
            //        }
            //        catch (InvalidOperationException)
            //        {
            //            Thread.Sleep(1000);
            //        }
            //    }
            //    else Thread.Sleep(1000);
            //}
        }
    }
}
