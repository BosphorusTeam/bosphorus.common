namespace Bosphorus.Common.Core.CoC.Convention
{
    public interface IConvention<in TConventionContext>
    {
        void Apply(TConventionContext context);
    }
}
