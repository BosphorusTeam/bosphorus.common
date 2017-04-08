namespace Bosphorus.Common.Api.CoC.Acceptance
{
    public interface IAcceptance<in TCriteriaContext>
    {
        void Accept(ICriteria<TCriteriaContext> criteria);
    }
}