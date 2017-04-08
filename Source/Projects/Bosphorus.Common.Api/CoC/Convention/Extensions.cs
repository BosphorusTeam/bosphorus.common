using System.Collections.Generic;
using Bosphorus.Common.Api.CoC.Acceptance;

namespace Bosphorus.Common.Api.CoC.Convention
{
    public static class Extensions
    {
        private static void ApplySafe<TContext>(this IConvention<TContext> extended, TContext context)
        {
            IAcceptance<TContext> acceptance = extended as IAcceptance<TContext>;
            if (acceptance == null)
            {
                extended.Apply(context);
                return;
            }

            DefaultCriteria<TContext> criteria = new DefaultCriteria<TContext>(context);
            acceptance.Accept(criteria);
            bool accepted = criteria.Result;
            if (!accepted)
            {
                return;
            }

            extended.Apply(context);
        }

        public static void Apply<TContext>(this IList<IConvention<TContext>> conventions, TContext context)
        {
            foreach (IConvention<TContext> convention in conventions)
            {
                ApplySafe(convention, context);
            }
        }

    }
}
