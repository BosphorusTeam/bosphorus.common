using System.Diagnostics;

namespace Bosphorus.Common.Clr.Diagnostic.Trace
{
    public class DefaultTraceSourceBuilder : ITraceSourceBuilder
    {
        public TraceSource Build(string name)
        {
            TraceSource traceSource = new TraceSource(name);
            traceSource.Switch.Level = SourceLevels.All;
            return traceSource;
        }
    }
}