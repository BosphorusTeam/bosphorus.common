namespace Bosphorus.Common.Core.Context.Application
{
    public class ApplicationContextProvider: IContextProvider<ApplicationContext>
    {
        private ApplicationContext applicationContext;

        public ApplicationContextProvider(IContextListener<ApplicationContext> applicationContextListener)
        {
            applicationContextListener.ContextStarted += ApplicationContextListenerOnContextStarted;
            applicationContextListener.ContextFinished += ApplicationContextListenerOnContextFinished;
        }

        private void ApplicationContextListenerOnContextStarted(object sender, ContextEventArgs<ApplicationContext> contextEventArgs)
        {
            applicationContext = contextEventArgs.Context;
        }

        public ApplicationContext Get()
        {
            return applicationContext;
        }

        private void ApplicationContextListenerOnContextFinished(object sender, ContextEventArgs<ApplicationContext> contextEventArgs)
        {
            applicationContext = null;
        }

    }
}
