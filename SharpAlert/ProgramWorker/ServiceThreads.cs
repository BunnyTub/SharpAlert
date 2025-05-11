using System.Threading;

namespace SharpAlert
{
    public static class ServiceThreads
    {
        public static Thread feedThread;
        public static Thread directfeedThread;
        public static Thread cacheThread;
        public static Thread dataProcThread;
        public static Thread historyProcThread;
        public static Thread notificationThread;
        public static Thread serverThread;
        public static Thread heartbeatThread;
    }
}
