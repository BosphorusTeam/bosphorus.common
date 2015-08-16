using System;

namespace Bosphorus.Common.Core.Call
{
    public interface ICallListener
    {
        event EventHandler<EventArgs> BeforeCall;
        event EventHandler<EventArgs> AfterCall;
    }
}