using System;

namespace Bosphorus.Common.Core.Application
{
    public interface IApplicationListener
    {
        event EventHandler<ApplicationStartEventArgs> AfterStarted;
        event EventHandler<EventArgs> AfterFinished;
    }
}