namespace Bosphorus.Common.Core.Context
{
    public interface IContextProvider<out TContext>
        where TContext: IContext
    {
        TContext Get();
    }
}
