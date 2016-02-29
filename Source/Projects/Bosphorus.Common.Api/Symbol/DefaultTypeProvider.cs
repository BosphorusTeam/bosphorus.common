using System;
using System.Collections.Generic;

namespace Bosphorus.Common.Api.Symbol
{
    public class DefaultTypeProvider : ITypeProvider
    {
        public IEnumerable<Type> LoadedTypes { get; }

        public DefaultTypeProvider(IEnumerable<Type> types)
        {
            LoadedTypes = types;
        }

    }
}