using System;

namespace Bosphorus.Common.Core.CoC.Acceptance
{
    public class DefaultCriteria<TInspectorContext> : ICriteria<TInspectorContext>
    {
        public TInspectorContext Context { get; }
        public bool Result { get; private set; }

        public DefaultCriteria(TInspectorContext context, bool result = true)
        {
            Context = context;
            Result = result;
        }

        public ICriteria<TInspectorContext> Expect(Func<TInspectorContext, bool> evaluation)
        {
            bool currentResult = evaluation(Context);
            Result = Result & currentResult;
            return this;
        }
    }
}