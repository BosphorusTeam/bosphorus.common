using System;
using Bosphorus.Common.Api.Context.Listener;

namespace Bosphorus.Common.Runtime.Application
{
    public class ApplicationContextInvoker
    {
        private readonly DefaultContextInvoker<ApplicationContext> inner;
        private readonly ApplicationContext applicationContext;

        public ApplicationContextInvoker(DefaultContextInvoker<ApplicationContext> inner, Environment environment, Perspective perspective, Host host)
        {
            this.inner = inner;
            this.applicationContext = new ApplicationContext(environment, perspective, host);
        }

        public void InvokeStarted()
        {
            inner.InvokeStarted(applicationContext);
        }

        public bool InvokeFailed(Exception exception)
        {
            var handled = inner.InvokeFailed(applicationContext, exception);
            return handled;
        }

        public void InvokeSuccessful()
        {
            inner.InvokeSuccessful(applicationContext);
        }

        public void InvokeFinished()
        {
            inner.InvokeFinished(applicationContext);
        }
    }
}
