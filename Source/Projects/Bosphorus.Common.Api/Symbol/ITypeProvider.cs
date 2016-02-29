using System;
using System.Collections.Generic;

namespace Bosphorus.Common.Api.Symbol
{
    public interface ITypeProvider
    {
        IEnumerable<Type> LoadedTypes { get; }
    }
}