using System;
using Bosphorus.Common.Core.Application;
using Environment = Bosphorus.Common.Core.Application.Environment;

namespace Bosphorus.BootStapper.Kernel
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