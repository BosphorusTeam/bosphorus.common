namespace Bosphorus.Common.Api.CoC.Convention
{
    public interface IConvention<in TConventionContext>
    {
        void Apply(TConventionContext context);
    }
}
