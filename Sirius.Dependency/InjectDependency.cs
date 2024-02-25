using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sirius.Domain.Entity;
using Sirius.Domain.Interface.Repository;
using Sirius.Domain.Interface.Service;
using Sirius.Repository;
using Sirius.Service;

namespace Sirius.Dependency
{
    public static class InjectDependency
    {
        public static void InjectDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            InjectServices(services);
            InjectRepository(services);
            InjectDataBase(services, configuration);
        }

        private static void InjectDataBase(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetSection("ConnectionString").Value ?? string.Empty;
            services.AddDbContext<SiriusContext>(options =>
            {
                options.UseNpgsql(connectionString!);
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            }, ServiceLifetime.Transient);
        }

        private static void InjectRepository(IServiceCollection services)
        {
            services.AddTransient<ICategoryRepository, CategoryRepository>();
        }

        private static void InjectServices(IServiceCollection services)
        {
            services.AddTransient<ICategoryService, CategoryService>();
        }
    }
}
