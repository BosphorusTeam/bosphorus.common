using System;
using Bosphorus.Common.Api.Context;

namespace Bosphorus.Common.Application.Scope.Call
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