using System;

namespace Bosphorus.BootStapper.Kernel
{
    public interface IApplicationListener
    {
        event EventHandler<ApplicationStartEventArgs> AfterStarted;
        event EventHandler<EventArgs> AfterFinished;
    }
}