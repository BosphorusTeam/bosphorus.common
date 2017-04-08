using System;
using System.Collections.Generic;

namespace Bosphorus.Common.Api.Reflectionn
{
    public interface ITypeProvider
    {
        IEnumerable<Type> LoadedTypes { get; }
    }
}