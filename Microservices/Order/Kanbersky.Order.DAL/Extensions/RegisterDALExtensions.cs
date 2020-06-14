using Kanbersky.Order.DAL.Concrete.EntityFramework.Context;
using Kanbersky.Order.DAL.Concrete.EntityFramework.GenericRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kanbersky.Order.DAL.Extensions
{
    public static class RegisterDALExtensions
    {
        public static void RegisterOrderDAL(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<OrderContext>(opt =>
            {
                opt.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"]);
            },
            ServiceLifetime.Singleton);

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        }
    }
}
