using System;
using System.Linq;
using Bosphorus.Common.Api.CoC.Convention;
using Castle.Core;
using Castle.MicroKernel;
using Castle.MicroKernel.ModelBuilder;
using Castle.Windsor;

namespace Bosphorus.Common.Api.Container.Coc
{
    public class ComponentModelConventionApplier: IContributeComponentModelConstruction
    {
        private readonly Lazy<IConventionApplier<ComponentModelAcceptance>> conventionApplier;
        private readonly IWindsorContainer container;

        public ComponentModelConventionApplier(Lazy<IConventionApplier<ComponentModelAcceptance>> conventionApplier, IWindsorContainer container)
        {
            this.conventionApplier = conventionApplier;
            this.container = container;
        }

        public void ProcessModel(IKernel kernel, ComponentModel model)
        {
            //HACK: If convention applier is not registered yet, so go on..
            if (!container.Kernel.HasComponent(typeof(IConventionApplier<>)))
            {
                return;
            }

            if (model.Services.Any(type => type == typeof(IConventionApplier<ComponentModelAcceptance>)))
            {
                return;
            }

            ComponentModelAcceptance acceptanceContext = new ComponentModelAcceptance(model);
            ComponentModelConvention conventionContext = new ComponentModelConvention(kernel, model);
            conventionApplier.Value.Apply(acceptanceContext, conventionContext);
        }
    }
}
