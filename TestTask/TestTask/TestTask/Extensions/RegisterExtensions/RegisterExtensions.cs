using Microsoft.Extensions.DependencyInjection;
using TestTask.Data;
using TestTast.Application;

namespace TestTask.Web.Extensions.RegisterExtensions
{
    public static class RegisterExtensions
    {
        public static void AddRegisterService(this IServiceCollection services)
        {
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }
    }
}
