using Castle.Windsor;

namespace Bosphorus.Common.Api.Context.Provider
{
    public class GenericContextProvider
    {
        private readonly IWindsorContainer container;

        public GenericContextProvider(IWindsorContainer container)
        {
            this.container = container;
        }

        public TContext Get<TContext>() 
            where TContext : IContext
        {
            IContextProvider<TContext> contextProvider = container.Resolve<IContextProvider<TContext>>();
            TContext result = contextProvider.Get();
            return result;
        }
    }
}
