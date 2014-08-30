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
    }
}
