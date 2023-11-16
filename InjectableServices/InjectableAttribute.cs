using Microsoft.Extensions.DependencyInjection;

namespace InjectableServices
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public sealed class InjectableAttribute : Attribute
    {
        public ServiceLifetime Lifetime { get; }

        public InjectableAttribute(ServiceLifetime Lifetime = ServiceLifetime.Scoped)
        {
            this.Lifetime = Lifetime;
        }
    }
}