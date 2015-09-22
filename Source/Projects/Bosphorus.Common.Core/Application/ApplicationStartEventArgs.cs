using System;

namespace Bosphorus.Common.Core.Application
{
    public class ApplicationStartEventArgs: EventArgs
    {
        public ApplicationStartEventArgs(Environment environment, Perspective perspective, Host host)
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