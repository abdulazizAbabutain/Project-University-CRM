using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using University_CRM.Application.Common.Interfaces;
using University_CRM.Infrastructure.Persistence;
using University_CRM.Infrastructure.Services;

namespace University_CRM.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastrucuteServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationContext>(option =>
            {
                option.UseSqlServer("Server=.;Database=University_CRM;User Id=sa;password=123");
            });

            services.AddScoped<IRepositoryManager, RepositoryManager>();
            return services;
        }
    }
}
