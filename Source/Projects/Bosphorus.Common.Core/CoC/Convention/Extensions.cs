using System.Collections.Generic;
using Bosphorus.Common.Core.CoC.Acceptance;
using Bosphorus.Common.Core.CoC.Convention;

namespace Bosphorus.NExt.JsProxy.Core.TempConv
{
    public static class Extensions
    {
        public static void ApplySafe<TInspectorContext>(this IConvention<TInspectorContext> extended, TInspectorContext context)
        {
            IAcceptance<TInspectorContext> acceptance = extended as IAcceptance<TInspectorContext>;
            if (acceptance == null)
            {
                extended.Apply(context);
                return;
            }

            ICriteria<TInspectorContext> criteria = new DefaultCriteria<TInspectorContext>(context);
            acceptance.Accept(criteria);
            bool accepted = criteria.Result;
            if (!accepted)
            {
                return;
            }

            extended.Apply(context);
        }

        public static void Apply<TInspectorContext>(this IList<IConvention<TInspectorContext>> extendedItems, TInspectorContext context)
        {
            foreach (IConvention<TInspectorContext> extended in extendedItems)
            {
                extended.ApplySafe(context);
            }
        }

    }
}
