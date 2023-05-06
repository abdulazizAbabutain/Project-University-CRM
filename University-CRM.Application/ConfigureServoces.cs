using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace University_CRM.Application
{
    public static class ConfigureServoces
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
            });
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;

        }
    }
}
