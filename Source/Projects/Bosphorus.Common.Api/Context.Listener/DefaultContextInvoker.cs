using System;

namespace Bosphorus.Common.Api.Context.Listener
{
    public class DefaultContextInvoker<TContext> : IContextListener<TContext> 
        where TContext : IContext
    {
        public event EventHandler<ContextEventArgs<TContext>> ContextStarted;
        public event EventHandler<ContextFailedEventArgs<TContext>> ContextFailed;
        public event EventHandler<ContextEventArgs<TContext>> ContextSuccessful;
        public event EventHandler<ContextEventArgs<TContext>> ContextFinished;

        public DefaultContextInvoker()
        {
            ContextStarted += delegate { };
            ContextFailed += delegate { };
            ContextSuccessful += delegate { };
            ContextFinished += delegate { };
        }

        public void InvokeStarted(TContext context)
        {
            var eventArgs = new ContextEventArgs<TContext>(context);
            ContextStarted(this, eventArgs);
        }

        public void InvokeFailed(TContext context, System.Exception exception)
        {
            var eventArgs = new ContextFailedEventArgs<TContext>(context, exception);
            ContextFailed(this, eventArgs);
        }

        public void InvokeSuccessful(TContext context)
        {
            var eventArgs = new ContextEventArgs<TContext>(context);
            ContextSuccessful(this, eventArgs);
        }

        public void InvokeFinished(TContext context)
        {
            var eventArgs = new ContextEventArgs<TContext>(context);
            ContextFinished(this, eventArgs);
        }

    }
}
