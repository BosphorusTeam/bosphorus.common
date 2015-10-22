using Bosphorus.Common.Core.Application;

namespace Bosphorus.Common.Core.Context.Application
{
    public class ApplicationContext : IContext
    {
        public ApplicationContext(Environment environment, Perspective perspective, Host host)
        {
            this.Environment = environment;
            this.Perspective = perspective;
            this.Host = host;
        }
        public Environment Environment { get; }

        public Perspective Perspective { get; }

        public Host Host { get; }

        public object Get(string key)
        {
            return null;
        }
    }
}