namespace Bosphorus.Common.Api.CoC.Convention
{
    public interface IConventionApplier<in TAcceptanceContext>
    {
        bool IsApplicable<TConventionContext>(TAcceptanceContext acceptanceContext);

        void Apply<TConventionContext>(TAcceptanceContext acceptanceContext, TConventionContext conventionContext);
    }
}
