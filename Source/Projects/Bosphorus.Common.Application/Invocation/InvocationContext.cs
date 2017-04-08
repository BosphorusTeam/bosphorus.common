using System;

namespace Bosphorus.Common.Runtime.Invocation
{
    public class InvocationContext
    {
        private readonly Guid id;

        public InvocationContext()
        {
            id = Guid.NewGuid();
        }

        public Guid? Id => id;

        public object Get(string key)
        {
            return null;
        }
    }
}
