using System;
using System.Collections.Generic;
using System.Linq;

namespace Bosphorus.Common.Api.Enum.Provider
{
    public static class EnumerationProviderExtensions
    {
        public static TEnumeration Parse<TEnumeration, TId>(this IEnumerationProvider<TEnumeration> enumerationProvider, TId id) 
            where TEnumeration : Enumeration<TId>
        {
            TEnumeration enumeration;
            bool result = TryParse(enumerationProvider, id, out enumeration);
            if (!result)
            {
                throw new EnumerationNotExistsBosphorusException<TId>(id);
            }

            return enumeration;
        }

        public static bool TryParse<TEnumeration, TId>(this IEnumerationProvider<TEnumeration> enumerationProvider, TId id, out TEnumeration enumeration)
            where TEnumeration: Enumeration<TId>
        {
            bool result = TryParse(enumerationProvider, item => item.Id.Equals(id), out enumeration);
            return result;
        }

        public static TEnumeration Parse<TEnumeration>(this IEnumerationProvider<TEnumeration> enumerationProvider, string name) 
            where TEnumeration : EnumerationBase
        {
            TEnumeration enumeration;
            bool result = TryParse(enumerationProvider, name, out enumeration);
            if (!result)
            {
                throw new EnumerationNotExistsBosphorusException<object>(name);
            }

            return enumeration;
        }

        public static bool TryParse<TEnumeration>(this IEnumerationProvider<TEnumeration> enumerationProvider, string name, out TEnumeration enumeration)
            where TEnumeration: EnumerationBase
        {
            bool result = TryParse(enumerationProvider, item => item.Name.Equals(name), out enumeration);
            return result;
        }

        private static bool TryParse<TEnumeration>(this IEnumerationProvider<TEnumeration> enumerationProvider, Func<TEnumeration, bool> predicate, out TEnumeration enumeration)
            where TEnumeration: EnumerationBase
        {
            IList<TEnumeration> enumerationList = enumerationProvider.GetAll();
            enumeration = enumerationList.FirstOrDefault(predicate);
            bool result = enumeration != null;
            return result;
        }
    }
}
