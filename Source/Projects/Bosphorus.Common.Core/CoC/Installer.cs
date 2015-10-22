using Bosphorus.Common.Core.CoC.Convention;
using Bosphorus.Container.Castle.Registration.Installer;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Bosphorus.Common.Core.CoC
{
    public class Installer: AbstractWindsorInstaller, IBootStrapInstaller
    {
        protected override void Install(IWindsorContainer container, IConfigurationStore store, FromTypesDescriptor allLoadedTypes)
        {
            container.Register(
                allLoadedTypes
                    .BasedOn(typeof(IConvention<>))
                    .WithService
                    .AllInterfaces(),

                Component
                    .For(typeof(IConventionApplier<>))
                    .ImplementedBy(typeof(DefaultConventionApplier<>))
            );
        }
    }
}
