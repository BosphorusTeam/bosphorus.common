using System;

namespace Bosphorus.Common.Runtime.Call
{
    public class CallContext
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