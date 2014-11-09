namespace Bosphorus.Common.Core.Context
{
    public interface IContext
    {
        object Get(string key);
    }
}
