using System;

namespace Bosphorus.Common.Api.CoC.Acceptance
{
    public interface ICriteria<out TCriteriaContext>
    {
        ICriteria<TCriteriaContext> Expect(Func<TCriteriaContext, bool> expectation);

    }
}