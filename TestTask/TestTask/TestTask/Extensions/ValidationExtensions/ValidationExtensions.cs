using Microsoft.Extensions.DependencyInjection;
using TestTask.Web.Models;

namespace TestTask.Web.Extensions.ValidationExtensions
{
    public static class ValidationExtensions
    {
        public static void AddValidation(this IServiceCollection services)
        {
            services.Configure<Microsoft.AspNetCore.Mvc.ApiBehaviorOptions>(options => 
                options.InvalidModelStateResponseFactory = ctx => new ValidationResult());
        }
    }
}
