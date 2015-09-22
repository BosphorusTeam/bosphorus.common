using System;

namespace Bosphorus.Common.Core.CoC.Acceptance
{
    public class DefaultCriteria<TCriteriaContext> : ICriteria<TCriteriaContext>
    {
        private readonly TCriteriaContext context;

        internal bool Result { get; private set; }

        public DefaultCriteria(TCriteriaContext context, bool result = true)
        {
            this.context = context;
            Result = result;
        }

        public ICriteria<TCriteriaContext> Expect(Func<TCriteriaContext, bool> expectation)
        {
            bool currentResult = expectation(this.context);
            Result = Result & currentResult;
            return this;
        }
    }
}