namespace Bosphorus.Common.Core.Context.Call
{
    public class CallContextProvider: IContextProvider<CallContext>
    {
        private CallContext callContext;

        public CallContextProvider(IContextListener<CallContext> callContextListener)
        {
            callContextListener.ContextStarted += CallContextListenerOnContextStarted;
            callContextListener.ContextFinished += CallContextListenerOnContextFinished;
        }

        private void CallContextListenerOnContextStarted(object sender, ContextEventArgs<CallContext> contextEventArgs)
        {
            callContext = contextEventArgs.Context;
        }

        public CallContext Get()
        {
            return callContext;
        }

        private void CallContextListenerOnContextFinished(object sender, ContextEventArgs<CallContext> contextEventArgs)
        {
            callContext = null;
        }
    }
}
