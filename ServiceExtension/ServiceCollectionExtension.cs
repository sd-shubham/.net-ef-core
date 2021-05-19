using System.Linq;
using CoreAPIAndEfCore.Common;
using Microsoft.Extensions.DependencyInjection;

namespace CoreAPIAndEfCore.ServiceExtension
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddNonGenericServices(this IServiceCollection services)
        {
            var transientType = typeof(ITransiantService);
            var scopedType = typeof(IScopedService);
            var singletonType = typeof(ISingletonService);
            var types = scopedType
            .Assembly
            .GetExportedTypes()
            .Where(t => t.IsClass && !t.IsAbstract)
            .Select(t => new
            {
                Service = t.GetInterface($"I{t.Name}"),
                Implementation = t
            })
            .Where(t => t.Service != null);
            foreach (var type in types)
            {
                if (transientType.IsAssignableFrom(type.Service)) services.AddTransient(type.Service, type.Implementation);
                else if (scopedType.IsAssignableFrom(type.Service)) services.AddScoped(type.Service, type.Implementation);
                else services.AddSingleton(type.Service, type.Implementation);
            }
            return services;
        }
    }
}