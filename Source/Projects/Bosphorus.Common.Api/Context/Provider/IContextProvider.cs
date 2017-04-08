namespace Bosphorus.Common.Api.Context.Provider
{
    public interface IContextProvider<out TContext>
    {
        TContext Get();
    }
}
