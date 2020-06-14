using Kanbersky.Product.Business.Abstract;
using Kanbersky.Product.Business.Concrete;
using Microsoft.Extensions.DependencyInjection;

namespace Kanbersky.Product.Business.Extensions
{
    public static class RegisterServiceExtensions
    {
        public static void RegisterProductServices(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
        }
    }
}
