using Bosphorus.Common.Api.CoC.Acceptance;
using Castle.Windsor;

namespace Bosphorus.Common.Api.CoC.Convention
{
    public class DefaultConventionApplier<TAcceptanceContext> : IConventionApplier<TAcceptanceContext>
    {
        private readonly IWindsorContainer container;

        public DefaultConventionApplier(IWindsorContainer container)
        {
            this.container = container;
        }

        public bool IsApplicable<TConventionContext>(TAcceptanceContext acceptanceContext)
        {
            IConvention<TConventionContext>[] conventions = container.ResolveAll<IConvention<TConventionContext>>();
            foreach (IConvention<TConventionContext> convention in conventions)
            {
                bool applicable = IsApplicable(acceptanceContext, convention);
                if (applicable)
                {
                    continue;
                }

                return false;
            }

            return true;
        }

        public void Apply<TConventionContext>(TAcceptanceContext acceptanceContext, TConventionContext conventionContext)
        {
            IConvention<TConventionContext>[] conventions = container.ResolveAll<IConvention<TConventionContext>>();
            foreach (IConvention<TConventionContext> convention in conventions)
            {
                bool applicable = IsApplicable(acceptanceContext, convention);
                if (!applicable)
                {
                    continue;
                }

                convention.Apply(conventionContext);
            }
        }


        private bool IsApplicable<TConventionContext>(TAcceptanceContext acceptanceContext, IConvention<TConventionContext> convention)
        {
            IAcceptance<TAcceptanceContext> acceptance = convention as IAcceptance<TAcceptanceContext>;
            if (acceptance == null)
            {
                return true;
            }

            DefaultCriteria<TAcceptanceContext> criteria = new DefaultCriteria<TAcceptanceContext>(acceptanceContext);
            acceptance.Accept(criteria);
            bool accepted = criteria.Result;
            return accepted;
        }

    }
}