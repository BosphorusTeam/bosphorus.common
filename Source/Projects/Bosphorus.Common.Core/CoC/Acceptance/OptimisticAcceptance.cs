namespace Bosphorus.Common.Core.CoC.Acceptance
{
    class OptimisticAcceptance<TAcceptanceContext> : IAcceptance<TAcceptanceContext>
    {
        public void Accept(ICriteria<TAcceptanceContext> criteria)
        {
            criteria.Expect(type => true);
        }
    }
}