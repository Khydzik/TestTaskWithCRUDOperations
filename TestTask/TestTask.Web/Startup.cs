using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestTask.Data;
using TestTask.Web.Extensions.EnsureMigration;
using TestTask.Web.Extensions.ExceptionHandleExtensions;
using TestTask.Web.Extensions.RegisterExtensions;
using TestTask.Web.Extensions.SwaggerExtentions;
using TestTask.Web.Extensions.ValidationExtensions;
using TestTask.Web.Formatters;

namespace TestTask
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataBaseContext>(options => options.UseSqlServer(
                _configuration.GetConnectionString("DefaultConnection"),
                apt => apt.MigrationsAssembly(typeof(DataBaseContext).Namespace)));
            services.AddMvc(options => {
                options.OutputFormatters.RemoveType(typeof(JsonOutputFormatter));
                options.OutputFormatters.Add(new CustomJsonOutputFormatter());
            }).AddDataAnnotationsLocalization().AddViewLocalization();
            services.AddValidation();
            services.AddSwaggerService();
            services.AddTransient<DataSeeder>();
            services.AddRegisterService();
        }

        public void Configure(IApplicationBuilder app, DataSeeder seeder, IHostingEnvironment env)
        {
            app.MigrationOfContext().GetAwaiter().GetResult();
            seeder.Seed().GetAwaiter().GetResult();
            app.UseStaticFiles();
            app.AddSwaggerConfig();
            app.AddExceptionHandler();
            app.UseMvc();
        }
    }
}
