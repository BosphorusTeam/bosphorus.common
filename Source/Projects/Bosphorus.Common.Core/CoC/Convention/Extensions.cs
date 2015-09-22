using System.Collections.Generic;
using Bosphorus.Common.Core.CoC.Acceptance;

namespace Bosphorus.Common.Core.CoC.Convention
{
    public static class Extensions
    {
        private static void ApplySafe<TConcentionContext>(this IConvention<TConcentionContext> extended, TConcentionContext context)
        {
            IAcceptance<TConcentionContext> acceptance = extended as IAcceptance<TConcentionContext>;
            if (acceptance == null)
            {
                extended.Apply(context);
                return;
            }

            DefaultCriteria<TConcentionContext> criteria = new DefaultCriteria<TConcentionContext>(context);
            acceptance.Accept(criteria);
            bool accepted = criteria.Result;
            if (!accepted)
            {
                return;
            }

            extended.Apply(context);
        }

        public static void Apply<TConventionContext>(this IList<IConvention<TConventionContext>> extendedItems, TConventionContext context)
        {
            foreach (IConvention<TConventionContext> extended in extendedItems)
            {
                extended.ApplySafe(context);
            }
        }

    }
}
