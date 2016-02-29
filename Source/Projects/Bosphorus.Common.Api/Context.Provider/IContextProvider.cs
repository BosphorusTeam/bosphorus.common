namespace Bosphorus.Common.Api.Context.Provider
{
    public interface IContextProvider<out TContext>
        where TContext: IContext
    {
        TContext Get();
    }
}
