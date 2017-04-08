using Bosphorus.Common.Api.Container;
using Bosphorus.Common.Api.Context.Listener;
using Bosphorus.Common.Api.Context.Provider;
using Bosphorus.Common.Api.Reflectionn;
using Castle.Facilities.Startable;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Bosphorus.Common.Api.Context
{
    public class Installer: IBosphorusInstaller
    {
        private readonly ITypeProvider typeProvider;

        public Installer(ITypeProvider typeProvider)
        {
            this.typeProvider = typeProvider;
        }

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register (
                Types
                    .From(typeProvider.LoadedTypes)
                    .BasedOn(typeof(IContextProvider<>))
                    .WithService
                    .FromInterface()
                    .Configure(ConfigureProvider),

                Component
                    .For<GenericContextProvider>(),

                Component
                    .For(typeof(IContextListener<>))
                    .Forward(typeof(DefaultContextInvoker<>))
                    .ImplementedBy(typeof(DefaultContextInvoker<>))
            );
        }

        private void ConfigureProvider(ComponentRegistration componentRegistration)
        {
            componentRegistration.LifeStyle.Singleton.Start();
        }
    }
}
