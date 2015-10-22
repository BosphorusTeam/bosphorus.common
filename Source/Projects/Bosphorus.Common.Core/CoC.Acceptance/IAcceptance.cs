namespace Bosphorus.Common.Core.CoC.Acceptance
{
    public interface IAcceptance<in TAcceptanceContext>
    {
        void Accept(ICriteria<TAcceptanceContext> criteria);
    }
}