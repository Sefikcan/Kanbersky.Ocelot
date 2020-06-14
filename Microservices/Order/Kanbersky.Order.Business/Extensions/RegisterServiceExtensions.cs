using AutoMapper;
using Kanbersky.Order.Business.Abstract;
using Kanbersky.Order.Business.Concrete;
using Kanbersky.Order.Business.Mappings.AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Kanbersky.Order.Business.Extensions
{
    /// <summary>
    /// Register Business Library Services
    /// </summary>
    public static class RegisterServiceExtensions
    {
        public static void RegisterOrderServices(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new BusinessProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderItemService, OrderItemService>();
        }
    }
}
