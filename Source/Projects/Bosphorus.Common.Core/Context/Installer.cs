using Bosphorus.Container.Castle.Registration.Installer;
using Castle.Facilities.Startable;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Bosphorus.Common.Core.Context
{
    public class Installer: AbstractWindsorInstaller, IInfrastructureInstaller
    {
        protected override void Install(IWindsorContainer container, IConfigurationStore store, FromTypesDescriptor allLoadedTypes)
        {
            container.Register(
                allLoadedTypes
                    .BasedOn(typeof(IContextProvider<>))
                    .WithService
                    .AllInterfaces()
                    .Configure(registration => registration.LifeStyle.Singleton.Start()),

                Component
                    .For<GenericContextProvider>(),

                Component
                    .For(typeof(IContextListener<>))
                    .Forward(typeof(ContextInvoker<>))
                    .ImplementedBy(typeof(ContextInvoker<>))
            );
        }
    }
}
