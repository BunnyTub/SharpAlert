using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using static SharpAlert.ProgramWorker.IceBearWorker;
using static SharpAlert.ProgramWorker.MainEntryPoint;

namespace SharpAlert
{
    public static class ThreadDrool
    {
        public static List<Thread> ServiceThreads = new List<Thread>();

        public class NonRestartableException : Exception
        {
        }

        public static Thread StartCatchAllThread(string FriendlyName, Action action, bool restartable, bool exceptionCausesUnsafeBehavior = true, ApartmentState apt = ApartmentState.MTA)
        {
            Console.WriteLine($"[Thread Drool] Returning thread. ({FriendlyName}, restartable = {restartable})");
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
                    catch (NonRestartableException)
                    {
                        restartable = false;
                    }
                    catch (Exception ex)
                    {
                        if (exceptionCausesUnsafeBehavior) UnsafeFault(ex, !restartable);
                    }

                    if (!restartable)
                    {
                        Console.WriteLine($"[Thread Drool] Closing thread. ({FriendlyName}, restartable = {restartable})");
                        return;
                    }
                    else
                    {
                        Console.WriteLine($"[Thread Drool] Restarting thread. ({FriendlyName}, restartable = {restartable})");
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
                Console.WriteLine($"[Thread Drool] Fire and forget is being rate limited. (action = {action.Method.Name})");
                Thread.Sleep(5000);
            }
            Console.WriteLine($"[Thread Drool] Starting fire and forget. (action = {action.Method.Name})");
            Task.Run(() =>
            {
                ThreadCount++;
                try
                {
                    action.Invoke();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[Thread Drool] {ex.Message} (action = {action.Method.Name})");
                }
                ThreadCount--;
            });
        }
    }
}

