using Bosphorus.Common.Api.Container;
using Bosphorus.Common.Runtime.Application;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Bosphorus.Common.Runtime
{
    public class Installer : IBosphorusInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component
                    .For<ApplicationContextInvoker>()
            );
        }
    }
}
