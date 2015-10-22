using System;

namespace Bosphorus.Common.Core.Context.Invocation
{
    public class InvocationContext: IContext
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
