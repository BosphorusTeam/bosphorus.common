using System;
using System.Linq;
using Bosphorus.Common.Api.CoC.Convention;
using Castle.Core;
using Castle.MicroKernel;
using Castle.MicroKernel.ModelBuilder;

namespace Bosphorus.Common.Api.Container.Coc
{
    public class ComponentModelConventionApplier: IContributeComponentModelConstruction
    {
        private readonly Lazy<IConventionApplier<ComponentModelAcceptance>> conventionApplier;

        public ComponentModelConventionApplier(Lazy<IConventionApplier<ComponentModelAcceptance>> conventionApplier)
        {
            this.conventionApplier = conventionApplier;
        }

        public void ProcessModel(IKernel kernel, ComponentModel model)
        {
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
