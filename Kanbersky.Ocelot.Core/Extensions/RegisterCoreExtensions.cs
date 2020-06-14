using Kanbersky.Ocelot.Core.Middlewares;
using Kanbersky.Ocelot.Core.Settings.Concrete;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kanbersky.Ocelot.Core.Extensions
{
    public static class RegisterCoreExtensions
    {
        public static void UseExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }

        public static void RegisterKanberskyCoreServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ElasticSearchSettings>(configuration.GetSection("ElasticSearchSettings"));
        }
    }
}
