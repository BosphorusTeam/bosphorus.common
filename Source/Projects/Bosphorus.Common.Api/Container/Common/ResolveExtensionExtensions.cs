using System.Collections.Generic;
using System.Linq;
using Castle.Core;
using Castle.MicroKernel.Handlers;
using Castle.MicroKernel.Registration;

namespace Bosphorus.Common.Api.Container.Common
{
    public static class ResolveExtensionExtensions
    {
        private const string PropertyKey = "Castle.ResolveExtensions";
        private static readonly IDictionary<object, List<IResolveExtension>> resolveExtensionsDictionary;

        static ResolveExtensionExtensions()
        {
            resolveExtensionsDictionary = new Dictionary<object, List<IResolveExtension>>();
        }

        public static List<IResolveExtension> GetResolveExtensions<TService>(this ComponentRegistration<TService> extended)
            where TService : class
        {
            if (!resolveExtensionsDictionary.ContainsKey(extended))
            {
                List<IResolveExtension> resolveExtensions = new List<IResolveExtension>();
                var property = Property.ForKey(PropertyKey).Eq(resolveExtensions);
                extended.ExtendedProperties(property);
                resolveExtensionsDictionary.Add(extended, resolveExtensions);
            }

            var result = resolveExtensionsDictionary[extended];
            return result;
        }

        public static List<IResolveExtension> GetResolveExtensions(this ComponentModel extended)
        {
            if (!resolveExtensionsDictionary.ContainsKey(extended))
            {
                List<IResolveExtension> resolveExtensions = new List<IResolveExtension>();
                extended.ExtendedProperties.Add(PropertyKey, resolveExtensions);
                resolveExtensionsDictionary.Add(extended, resolveExtensions);
            }

            var result = resolveExtensionsDictionary[extended];
            return result;
        }

        public static TResolveExtension Get<TResolveExtension>(this List<IResolveExtension> extended) 
            where TResolveExtension : IResolveExtension, new()
        {
            var found = extended.FirstOrDefault(extension => extended.GetType() == typeof(TResolveExtension));
            if (found != null)
            {
                return (TResolveExtension) found;
            }

            TResolveExtension result = new TResolveExtension();
            extended.Add(result);
            return result;
        }
    }
}
