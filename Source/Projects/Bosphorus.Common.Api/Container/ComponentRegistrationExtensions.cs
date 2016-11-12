using System;
using Castle.MicroKernel.Registration;

namespace Bosphorus.Common.Api.Container
{
    public static class ComponentRegistrationExtensions
    {
        public static ComponentRegistration<TService> NamedFull<TService>(this ComponentRegistration<TService> extended)
            where TService : class
        {
            Type serviceType = typeof (TService);
            Type implementationType = extended.Implementation;
            string name = $"{serviceType} - {implementationType}";
            extended.Named(name);
            return extended;
        }

    }
}
