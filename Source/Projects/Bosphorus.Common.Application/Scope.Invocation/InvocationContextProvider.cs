using System.Collections.Generic;
using Bosphorus.Common.Api.Context;
using Bosphorus.Common.Api.Context.Listener;
using Bosphorus.Common.Api.Context.Provider;

namespace Bosphorus.Common.Application.Scope.Invocation
{
    public class InvocationContextProvider: IContextProvider<InvocationContext>
    {
        private readonly Stack<InvocationContext> invocationContextStack;

        public InvocationContextProvider(IContextListener<InvocationContext> contextListener)
        {
            contextListener.ContextStarted += ContextListenerOnContextStarted;
            contextListener.ContextFinished += ContextListenerOnContextFinished;
            invocationContextStack = new Stack<InvocationContext>();
        }

        private void ContextListenerOnContextStarted(object sender, ContextEventArgs<InvocationContext> contextEventArgs)
        {
            InvocationContext context = contextEventArgs.Context;
            invocationContextStack.Push(context);
        }

        public InvocationContext Get()
        {
            InvocationContext result = invocationContextStack.Peek();
            return result;
        }

        private void ContextListenerOnContextFinished(object sender, ContextEventArgs<InvocationContext> contextEventArgs)
        {
            invocationContextStack.Pop();
        }
    }
}
