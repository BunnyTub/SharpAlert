using System;
using System.Threading;

namespace SharpAlert
{
    public static class ServiceThreads
    {
        private static Thread DummyThread()
        {
            return new Thread(() => throw new Exception("Caller executed dummy thread. This may be unintended behavior."));
        } 

        public static Thread feedThread = DummyThread();
        public static Thread atomfeedThread = DummyThread();
        public static Thread directfeedThread = DummyThread();
        public static Thread cacheThread = DummyThread();
        public static Thread dataProcThread = DummyThread();
        public static Thread historyProcThread = DummyThread();
        public static Thread notificationThread = DummyThread();
        public static Thread serverThread = DummyThread();
        public static Thread heartbeatThread = DummyThread();
    }
}
