using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Bosphorus.Common.Clr.Enum.Provider
{
    public class DefaultEnumerationProvider<TEnumeration> : IEnumerationProvider<TEnumeration> 
        where TEnumeration : EnumerationBase
    {
        private readonly IList<TEnumeration> enumerationList;

        public DefaultEnumerationProvider(IAssemblyProvider assemblyProvider)
        {
            this.enumerationList = GetEnumerationList(assemblyProvider);
        }

        private IList<TEnumeration> GetEnumerationList(IAssemblyProvider assemblyProvider)
        {
            Type enumerationType = typeof(TEnumeration);
            Type registerationClass = typeof(IEnumerationRegistration<TEnumeration>);
            IEnumerable<Type> registrationClasses = assemblyProvider.GetAssemblies()
                .SelectMany(assembly => assembly.GetTypes())
                .Where(type => registerationClass.IsAssignableFrom(type));

            List<TEnumeration> result = registrationClasses
                .SelectMany(type => type.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly))
                .Where(info => enumerationType.IsAssignableFrom(info.FieldType))
                .Select(info => info.GetValue(null))
                .Cast<TEnumeration>()
                .ToList();

            return result;
        }

        public IList<TEnumeration> GetAll()
        {
            return enumerationList;
        }
    }
}