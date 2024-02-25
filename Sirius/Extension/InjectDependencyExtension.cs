using Microsoft.EntityFrameworkCore;
using Sirius.Domain.Entity;
using Sirius.Domain.Interface.Repository;
using Sirius.Domain.Interface.Service;
using Sirius.Provider;
using Sirius.Repository;
using Sirius.Service;

namespace Sirius.Extension
{
    public static class InjectDependencyExtension
    {
        public static void InjectDependency(this IServiceCollection services, IConfiguration configuration)
        {
            InjectProvider(services);
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

        private static void InjectProvider(IServiceCollection services)
        {
            services.AddSingleton<DialogProvider>();
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
