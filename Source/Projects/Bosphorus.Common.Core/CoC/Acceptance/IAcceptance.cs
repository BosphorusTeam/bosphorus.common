namespace Bosphorus.Common.Core.CoC.Acceptance
{
    public interface IAcceptance<in TInspectorContext>
    {
        void Accept(ICriteria<TInspectorContext> criteria);
    }
}