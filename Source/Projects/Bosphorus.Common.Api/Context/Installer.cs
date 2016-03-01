using Bosphorus.Common.Api.Container;
using Bosphorus.Common.Api.Context.Listener;
using Bosphorus.Common.Api.Context.Provider;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Bosphorus.Common.Api.Context
{
    public class Installer: IBosphorusInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register (
                Component
                    .For<GenericContextProvider>(),

                Component
                    .For(typeof(IContextListener<>))
                    .Forward(typeof(DefaultContextInvoker<>))
                    .ImplementedBy(typeof(DefaultContextInvoker<>))
            );
        }
    }
}
