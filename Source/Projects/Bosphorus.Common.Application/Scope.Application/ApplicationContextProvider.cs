using Bosphorus.Common.Api.Context;
using Bosphorus.Common.Api.Context.Listener;
using Bosphorus.Common.Api.Context.Provider;

namespace Bosphorus.Common.Application.Scope.Application
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
