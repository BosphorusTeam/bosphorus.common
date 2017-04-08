namespace Bosphorus.Common.Runtime.Application
{
    public class ApplicationContext
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
    }
}