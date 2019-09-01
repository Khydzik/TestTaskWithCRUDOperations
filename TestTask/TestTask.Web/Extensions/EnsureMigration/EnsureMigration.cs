using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using TestTask.Data;

namespace TestTask.Web.Extensions.EnsureMigration
{
    public static class EnsureMigration
    {
        public static async Task MigrationOfContext(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<DataBaseContext>();
                if (!context.Database.EnsureCreated())
                {
                    context.Database.Migrate();
                }
            }
        }
    }
}
