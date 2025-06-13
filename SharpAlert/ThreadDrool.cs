using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using static SharpAlert.IceBearWorker;
using static SharpAlert.MainEntryPoint;

namespace SharpAlert
{
    public static class ThreadDrool
    {
        public static List<Thread> ServiceThreads = new List<Thread>();

        public static Thread StartCatchAllThread(Action action, bool restartable, ApartmentState apt = ApartmentState.MTA)
        {
            ConsoleExt.WriteLine($"[Thread Drool] Returning thread. (action = {action.Method.Name}, restartable = {restartable})");
            Thread thread = new Thread(() =>
            {
                while (AllowThreadRestarts)
                {
                    try
                    {
                        action.Invoke();
                    }
                    catch (ThreadAbortException)
                    {
                        return;
                    }
                    catch (Exception ex)
                    {
                        UnsafeFault(ex, !restartable);
                    }

                    if (!restartable)
                    {
                        ConsoleExt.WriteLine($"[Thread Drool] Closing thread. (action = {action.Method.Name}, restartable = {restartable})");
                        return;
                    }
                    else
                    {
                        ConsoleExt.WriteLine($"[Thread Drool] Restarting thread. (action = {action.Method.Name}, restartable = {restartable})");
                    }
                }
            });
            thread.SetApartmentState(apt);
            thread.Start();
            lock (ServiceThreads) ServiceThreads.Add(thread);
            return thread;
        }

        private static int ThreadCount = 0;
        private static readonly int ThreadCountRateLimit = 50;

        public static void StartAndForget(Action action)
        {
            if (ThreadCount > ThreadCountRateLimit)
            {
                ConsoleExt.WriteLine($"[Thread Drool] Fire and forget is being rate limited. (action = {action.Method.Name})");
                Thread.Sleep(5000);
            }
            ConsoleExt.WriteLine($"[Thread Drool] Starting fire and forget. (action = {action.Method.Name})");
            Task.Run(() =>
            {
                ThreadCount++;
                try
                {
                    action.Invoke();
                }
                catch (Exception ex)
                {
                    ConsoleExt.WriteLine($"[Thread Drool] {ex.Message} (action = {action.Method.Name})");
                }
                ThreadCount--;
            });
        }
    }
}
