using Castle.Windsor;

namespace Bosphorus.Common.Core.Context
{
    public class GenericContextProvider
    {
        private readonly IWindsorContainer windsorContainer;

        public GenericContextProvider(IWindsorContainer windsorContainer)
        {
            this.windsorContainer = windsorContainer;
        }

        public TContext Get<TContext>() 
            where TContext : IContext
        {
            IContextProvider<TContext> contextProvider = windsorContainer.Resolve<IContextProvider<TContext>>();
            TContext result = contextProvider.Get();
            return result;
        }
    }
}
