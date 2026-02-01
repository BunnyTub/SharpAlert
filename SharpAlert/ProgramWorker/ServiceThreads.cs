using System;
using System.Threading;

namespace SharpAlert.ProgramWorker
{
    public static class ServiceThreads
    {
        private static Thread DummyThread()
        {
            return new Thread(() => throw new Exception("Caller executed dummy thread. This may be unintended behavior."));
        } 

        internal static Thread FeedThread { get; set; } = DummyThread();
        internal static Thread AtomfeedThread { get; set; } = DummyThread();
        internal static Thread DirectfeedThread { get; set; } = DummyThread();
        internal static Thread IdapfeedThread { get; set; } = DummyThread();
        internal static Thread CacheThread { get; set; } = DummyThread();
        internal static Thread DataProcThread { get; set; } = DummyThread();
        internal static Thread HistoryProcThread { get; set; } = DummyThread();
        internal static Thread NotificationThread { get; set; } = DummyThread();
        internal static Thread ServerThread { get; set; } = DummyThread();
        internal static Thread HeartbeatThread { get; set; } = DummyThread();
    }
}

