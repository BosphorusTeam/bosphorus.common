using System.Diagnostics;

namespace Bosphorus.Common.Clr.Diagnostic.Trace
{
    public static class TraceSourceExtensions
    {
        private static int id = 0;

        public static void Info(this TraceSource traceSource, string message, object data)
        {
            TraceModel traceModel = new TraceModel(message, data);
            Trace(traceSource, TraceEventType.Information, traceModel);
        }

        public static void Warning(this TraceSource traceSource, string message, object data)
        {
            TraceModel traceModel = new TraceModel(message, data);
            Trace(traceSource, TraceEventType.Warning, traceModel);
        }

        public static void Error(this TraceSource traceSource, string message, object data)
        {
            TraceModel traceModel = new TraceModel(message, data);
            Trace(traceSource, TraceEventType.Error, traceModel);
        }

        private static void Trace(TraceSource traceSource, TraceEventType traceEventType, TraceModel traceModel)
        {
            traceSource.TraceData(traceEventType, id++, traceModel);
        }
    }
}
