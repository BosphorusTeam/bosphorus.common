using System;

namespace Bosphorus.Common.Core.Context
{
    public class ContextInvoker<TContext> : IContextListener<TContext> 
        where TContext : IContext
    {
        public event EventHandler<ContextEventArgs<TContext>> ContextStarted;
        public event EventHandler<ContextEventArgs<TContext>> ContextFinished;

        public ContextInvoker()
        {
            ContextStarted += delegate { };
            ContextFinished += delegate { };
        }

        public void InvokeStarted(TContext context)
        {
            ContextEventArgs<TContext> eventArgs = new ContextEventArgs<TContext>(context);
            ContextStarted(this, eventArgs);
        }

        public void InvokeFinished(TContext context)
        {
            ContextEventArgs<TContext> eventArgs = new ContextEventArgs<TContext>(context);
            ContextFinished(this, eventArgs);
        }

    }
}
