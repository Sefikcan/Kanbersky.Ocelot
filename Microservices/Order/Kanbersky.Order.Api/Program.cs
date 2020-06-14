using Kanbersky.Ocelot.Core.Helpers;
using Kanbersky.Ocelot.Core.Helpers.Logging;
using Kanbersky.Ocelot.Core.Settings.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;

namespace Kanbersky.Order.Api
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
            //https://www.humankode.com/asp-net-core/logging-with-elasticsearch-kibana-asp-net-core-and-docker
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
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
