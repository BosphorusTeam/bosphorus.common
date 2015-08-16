using System;

namespace Bosphorus.Common.Core.Context
{
    public class CallContext : IContext
    {
        public CallContext()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; }

        public object Get(string key)
        {
            return null;
        }
    }
}