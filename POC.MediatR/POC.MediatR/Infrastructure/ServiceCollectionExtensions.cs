using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace POC.MediatR.Infrastructure
{
    [ExcludeFromCodeCoverage]
    internal static class ServiceCollectionExtensions
    {
        public static void RegisterAllTypes(this IServiceCollection services, Assembly assembly, Type baseType,
            ServiceLifetime lifetime = ServiceLifetime.Scoped)
        {
            foreach (var type in assembly.GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract))
            {
                foreach (var i in type.GetInterfaces()
                    .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == baseType))
                {
                    // NOTE: Due to a limitation of Microsoft.DependencyInjection we cannot 
                    // register an open generic interface type without also having an open generic 
                    // implementation type. So, we convert to a closed generic interface 
                    // type to register.
                    var interfaceType = baseType.MakeGenericType(i.GetGenericArguments());
                    services.Add(new ServiceDescriptor(interfaceType, type, lifetime));
                }
            }
        }
    }
}