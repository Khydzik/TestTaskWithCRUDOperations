using TestTask.Application;
using TestTask.Data;
using Microsoft.Extensions.DependencyInjection;

namespace TestTask.Web.Extensions.RegisterExtensions
{
    public static class RegisterExtensions
    {
        public static void AddRegisterService(this IServiceCollection services)
        {
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IBookRepository, BookRepository>();
        }
    }
}
