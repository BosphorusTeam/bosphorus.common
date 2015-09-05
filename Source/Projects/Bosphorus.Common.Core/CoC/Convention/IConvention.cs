namespace Bosphorus.Common.Core.CoC.Convention
{
    public interface IConvention<in TInspectorContext>
    {
        void Apply(TInspectorContext context);
    }
}
