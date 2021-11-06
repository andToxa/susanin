using Infrastructure.Common.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Infrastructure.Web.Application
{
    /// <summary><see cref="Program"/></summary>
    public static class Program
    {
        /// <summary><see cref="Main"/></summary>
        /// <param name="args">Command line arguments</param>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                        .UseLogging()
                        .UseStartup<Startup>();
                });
    }
}