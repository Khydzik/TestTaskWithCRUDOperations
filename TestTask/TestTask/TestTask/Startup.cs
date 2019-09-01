using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestTask.Data;
using TestTask.Web.Extensions.ExceptionHandleExtensions;
using TestTask.Web.Extensions.CorsExtensions;
using TestTask.Web.Extensions.RegisterExtensions;
using TestTask.Web.Extensions.ValidationExtensions;
using TestTask.Web.Formatters;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace TestTask
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IConfiguration _configuration { get; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataBaseContext>(options => options.UseSqlServer(
                _configuration.GetConnectionString("DefaultConnection"),
                apt => apt.MigrationsAssembly(typeof(DataBaseContext).Namespace)));
            services.AddMvc(options =>
            {
                options.OutputFormatters.RemoveType(typeof(JsonOutputFormatter));
                options.OutputFormatters.Add(new CustomJsonOutputFormatter());
            });
            services.AddCorsService();
            services.AddValidation();
            services.AddRegisterService();
        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.AddExceptionHandler();
            app.AddCorsConfig();
            app.UseMvc();
        }
    }
}


