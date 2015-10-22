using System;

namespace Bosphorus.Common.Core.Context
{
    public class ContextEventArgs<TContext>: EventArgs
        where TContext: IContext
    {
        public TContext Context { get; }

        public ContextEventArgs(TContext context)
        {
            Context = context;
        }
    }
}