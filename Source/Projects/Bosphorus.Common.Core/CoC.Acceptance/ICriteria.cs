using System;

namespace Bosphorus.Common.Core.CoC.Acceptance
{
    public interface ICriteria<out TCriteriaContext>
    {
        ICriteria<TCriteriaContext> Expect(Func<TCriteriaContext, bool> expectation);

    }
}