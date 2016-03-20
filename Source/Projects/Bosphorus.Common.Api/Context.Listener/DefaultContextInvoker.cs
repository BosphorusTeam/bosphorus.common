using System;

namespace Bosphorus.Common.Api.Context.Listener
{
    public class DefaultContextInvoker<TContext> : IContextListener<TContext> 
        where TContext : IContext
    {
        public event EventHandler<ContextEventArgs<TContext>> ContextStarted;
        public event EventHandler<ContextEventArgs<TContext>> ContextFailed;
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
            ContextEventArgs<TContext> eventArgs = new ContextEventArgs<TContext>(context);
            ContextStarted(this, eventArgs);
        }

        public void InvokeFailed(TContext context)
        {
            ContextEventArgs<TContext> eventArgs = new ContextEventArgs<TContext>(context);
            ContextFailed(this, eventArgs);
        }

        public void InvokeSuccessful(TContext context)
        {
            ContextEventArgs<TContext> eventArgs = new ContextEventArgs<TContext>(context);
            ContextSuccessful(this, eventArgs);
        }

        public void InvokeFinished(TContext context)
        {
            ContextEventArgs<TContext> eventArgs = new ContextEventArgs<TContext>(context);
            ContextFinished(this, eventArgs);
        }

    }
}
