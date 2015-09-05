namespace Bosphorus.Common.Core.CoC.Acceptance
{
    class OptimisticAcceptance<TInspectorContext> : IAcceptance<TInspectorContext>
    {
        public void Accept(ICriteria<TInspectorContext> criteria)
        {
            criteria.Expect(type => true);
        }
    }
}