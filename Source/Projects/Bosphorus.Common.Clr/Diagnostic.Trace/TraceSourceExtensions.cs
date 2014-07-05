using System.Diagnostics;

namespace Bosphorus.Common.Clr.Diagnostic.Trace
{
    public static class TraceSourceExtensions
    {
        private static int id = 0;

        public static void Info(this TraceSource traceSource, string message, Method method)
        {
            Trace(traceSource, TraceEventType.Information, message, method);
        }

        public static void Warning(this TraceSource traceSource, string message, Method method)
        {
            Trace(traceSource, TraceEventType.Warning, message, method);
        }

        public static void Error(this TraceSource traceSource, string message, Method method)
        {
            Trace(traceSource, TraceEventType.Error, message, method);
        }

        private static void Trace(TraceSource traceSource, TraceEventType traceEventType, string message, Method method)
        {
            string methodString = method.ToString();
            traceSource.TraceData(traceEventType, id++, message, methodString);
        }
    }
}
