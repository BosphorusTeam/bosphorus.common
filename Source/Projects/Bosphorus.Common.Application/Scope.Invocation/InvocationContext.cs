using System;
using Bosphorus.Common.Api.Context;

namespace Bosphorus.Common.Application.Scope.Invocation
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
