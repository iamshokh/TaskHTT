using TaskHTT.ServiceLayer.CategoryService;
using TaskHTT.ServiceLayer.ProductService;

namespace TaskHTT.Web.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
        }
    }
}
