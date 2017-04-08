using System;

namespace Bosphorus.Common.Api.Context.Listener
{
    public class ContextEventArgs<TContext>: EventArgs
    {
        public TContext Context { get; }

        public ContextEventArgs(TContext context)
        {
            Context = context;
        }
    }
}