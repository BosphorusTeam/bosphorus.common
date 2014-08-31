using System.Diagnostics;

namespace Bosphorus.Common.Clr.Diagnostic
{
    public class TraceSourceEx
    {
        private readonly TraceSource traceSource;

        public TraceSourceEx(string name)
        {
            traceSource = new TraceSource(name, SourceLevels.All);
            
        }

        public void Critical(string message, params object[] parameters)
        {
            TraceEvent(TraceEventType.Critical, 0, message, parameters);
        }

        public void Error(string message, params object[] parameters)
        {
            traceSource.TraceEvent(TraceEventType.Error, 0, message, parameters);
        }

        public void Information(string message, params object[] parameters)
        {
            traceSource.TraceEvent(TraceEventType.Information, 0, message, parameters);
        }

        public void Verbose(string message, params object[] parameters)
        {
            traceSource.TraceEvent(TraceEventType.Verbose, 0, message, parameters);
        }

        public void Warning(string message, params object[] parameters)
        {
            traceSource.TraceEvent(TraceEventType.Warning, 0, message, parameters);
        }

        private void TraceEvent(TraceEventType traceEventType, int i, string message, object[] parameters)
        {
            traceSource.TraceEvent(traceEventType, 0, message, parameters);
        }

    }
}
