using Autofac.Extensions.DependencyInjection;
using Kanbersky.Ocelot.Core.Helpers;
using Kanbersky.Ocelot.Core.Helpers.Logging;
using Kanbersky.Ocelot.Core.Settings.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;

namespace Kanbersky.Product.Api
{
    /// <summary>
    /// 
    /// </summary>
    public class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            var logServerSettings = BaseHelpers.GetConfigurationRoot(args).GetSection("ElasticSearchSettings").Get<ElasticSearchSettings>();
            Log.Logger = new LoggerHelpers(logServerSettings).Register(typeof(Startup).Assembly.GetName().Name, LogEventLevel.Warning);

            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .UseServiceProviderFactory(new AutofacServiceProviderFactory())
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
    }
}
