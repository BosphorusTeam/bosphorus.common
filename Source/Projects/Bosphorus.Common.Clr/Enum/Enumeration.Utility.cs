using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Bosphorus.Common.Clr.Enum
{
    public partial class Enumeration<TEnumeration, TId>
    {
        private static readonly Lazy<IList<TEnumeration>> enumerationList;

        static Enumeration()
        {
            enumerationList = new Lazy<IList<TEnumeration>>(Load);
        }

        protected static TNewEnumeration Create<TNewEnumeration>(TId id, string name)
            where TNewEnumeration: TEnumeration, new()
        {
            TNewEnumeration enumeration = new TNewEnumeration();
            enumeration.Id = id;
            enumeration.Name = name;

            return enumeration;
        }

        private static IList<TEnumeration> Load()
        {
            Type enumerationType = typeof(TEnumeration);
            return enumerationType
                .GetFields(BindingFlags.Public | BindingFlags.Static)
                .Where(info => enumerationType.IsAssignableFrom(info.FieldType))
                .Select(info => info.GetValue(null))
                .Cast<TEnumeration>()
                .ToList();
        }

        public static IList<TEnumeration> GetAll()
        {
            return enumerationList.Value;
        }


        public static TEnumeration Parse(TId id)
        {
            TEnumeration enumeration;
            bool result = TryParse(id, out enumeration);
            if (!result)
            {
                throw new EnumerationNotExistsException<TId>(id);
            }

            return enumeration;
        }

        public static TEnumeration Parse(string name)
        {
            TEnumeration enumeration;
            bool result = TryParse(name, out enumeration);
            if (!result)
            {
                throw new EnumerationNotExistsException<TId>(name);
            }

            return enumeration;
        }

        public static bool TryParse(TId id, out TEnumeration enumeration)
        {
            bool result = TryParse(item => item.Id.Equals(id), out enumeration);
            return result;
        }

        public static bool TryParse(string name, out TEnumeration enumeration)
        {
            bool result = TryParse(item => item.Name.Equals(name), out enumeration);
            return result;
        }

        private static bool TryParse(Func<TEnumeration, bool> predicate, out TEnumeration enumeration)
        {
            enumeration = enumerationList.Value.FirstOrDefault(predicate);
            bool result = enumeration != null;
            return result;
        }

    }
}
