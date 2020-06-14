using Kanbersky.Product.DAL.Concrete.Dapper;
using Microsoft.Extensions.DependencyInjection;

namespace Kanbersky.Product.DAL.Extensions
{
    public static class RegisterDALExtensions
    {
        public static void RegisterProductDAL(this IServiceCollection services)
        {
            services.AddSingleton<IProductDbConnection, ProductDbConnection>();
        }
    }
}
