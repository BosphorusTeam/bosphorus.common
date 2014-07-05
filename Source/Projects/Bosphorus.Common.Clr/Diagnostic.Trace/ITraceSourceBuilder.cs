using System.Diagnostics;

namespace Bosphorus.Common.Clr.Diagnostic.Trace
{
    public interface ITraceSourceBuilder
    {
        TraceSource Build(string name);
    }
}
