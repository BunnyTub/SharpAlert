using System;
using System.Net.Http;
using System.Threading;

namespace SharpAlert
{
    public class CacheCapture
    {
        private readonly HttpClient client;

        public CacheCapture()
        {
            client = new HttpClient
            {
                Timeout = TimeSpan.FromSeconds(30)
            };
            client.DefaultRequestHeaders.UserAgent.ParseAdd($"Mozilla/5.0 (compatible; SharpAlert)");
        }

        public static string SAME_US_JSON
        {
            get;
            private set;
        }

        private static readonly string SAME_US_URL = "https://raw.githubusercontent.com/Newton-Communications/E2T/refs/heads/nwr-localities/EAS2Text/same-us.json";

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
            while (Stop) Thread.Sleep(100);
        }

        public void ServiceRun(bool loop)
        {
            while (true)
            {
                try
                {
                    SAME_US_JSON = client.GetStringAsync($"{SAME_US_URL}").Result;
                    Console.WriteLine($"[Cache Capture | SAME-US] Grabbed data.");
                }
                catch (Exception ex) { Console.WriteLine($"[Cache Capture | SAME-US] {ex.Message}"); }

                if (!loop)
                {
                    Console.WriteLine($"[Cache Capture] The cache has been filled.");
                    return;
                }

                Console.WriteLine($"[Cache Capture] The cache has been filled automatically.");

                for (int i = 0; !(i >= 1800);)
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
        }
    }
}