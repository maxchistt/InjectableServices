using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;
using System.Reflection;

namespace InjectableServices
{
    public static class InjectableServicesExtension
    {
        public static void AddInjectableServices(this IServiceCollection services)
        {
            var classesWithAttribute = Assembly.GetEntryAssembly()!.GetTypes()
                .Where(type => type.IsClass && type.GetCustomAttribute<InjectableAttribute>() is not null);

            foreach (var classType in classesWithAttribute)
            {
                if (classType is null) continue;
                var attr = classType.GetCustomAttribute<InjectableAttribute>();
                if (attr is null) continue;

                Debug.WriteLine($"{classType.Name} is {attr.Lifetime} service");

                foreach (var interfaceType in classType.GetInterfaces())
                {
                    services.Add(new(interfaceType, classType, attr.Lifetime));
                    Debug.WriteLine($"{classType.Name} added as {attr.Lifetime} service of type {interfaceType.Name}");
                }
            }
        }
    }
}