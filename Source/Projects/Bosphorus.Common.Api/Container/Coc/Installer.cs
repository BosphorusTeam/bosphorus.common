using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Bosphorus.Common.Api.Container.Coc
{
    public class Installer: IBosphorusInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component
                    .For<ComponentModelConventionApplier>()
            );

            var componentModelConstructionConvention = container.Resolve<ComponentModelConventionApplier>();
            container.Kernel.ComponentModelBuilder.AddContributor(componentModelConstructionConvention);
        }
    }
}
