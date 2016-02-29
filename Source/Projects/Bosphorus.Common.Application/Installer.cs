using Bosphorus.Common.Api.Context.Provider;
using Bosphorus.Common.Application.Scope.Application;
using Bosphorus.Common.Application.Scope.Call;
using Bosphorus.Common.Application.Scope.Invocation;
using Castle.Facilities.Startable;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Bosphorus.Common.Application
{
    public class Installer : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component
                    .For<IContextProvider<ApplicationContext>>()
                    .ImplementedBy<ApplicationContextProvider>()
                    .LifeStyle
                    .Singleton
                    .Start(),

                Component
                    .For<ApplicationContextProvider>(),

                Component
                    .For<IContextProvider<CallContext>>()
                    .ImplementedBy<CallContextProvider>()
                    .LifeStyle
                    .Singleton
                    .Start(),

                Component
                    .For<IContextProvider<InvocationContext>>()
                    .ImplementedBy<InvocationContextProvider>()
                    .LifeStyle
                    .Singleton
                    .Start()
            );
        }
    }
}
