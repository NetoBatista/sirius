using Microsoft.EntityFrameworkCore;
using Sirius.Domain.Entity;

namespace Sirius.Extension
{
    public static class MigrationExtension
    {
        public static void ExecuteMigrations(this IServiceCollection services)
        {
            var provider = services.BuildServiceProvider();
            var migrationService = provider.GetService<SiriusContext>();
            if (migrationService == null)
            {
                return;
            }
            var pendingMigrations = migrationService.Database.GetPendingMigrations();
            if (pendingMigrations.Any())
            {
                migrationService.Database.Migrate();
            }
        }
    }
}
