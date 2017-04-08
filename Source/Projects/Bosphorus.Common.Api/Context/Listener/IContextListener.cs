using System;

namespace Bosphorus.Common.Api.Context.Listener
{
    public interface IContextListener<TContext>
    {
        event EventHandler<ContextEventArgs<TContext>> ContextStarted;
        event EventHandler<ContextFailedEventArgs<TContext>> ContextFailed;
        event EventHandler<ContextEventArgs<TContext>> ContextSuccessful;
        event EventHandler<ContextEventArgs<TContext>> ContextFinished;
    }
}