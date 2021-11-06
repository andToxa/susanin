using Application.Example.Extensions;
using Infrastructure.Example.Extensions;
using Infrastructure.Web.Common.Extensions.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace Infrastructure.Web.Application
{
    /// <summary><see cref="Startup"/></summary>
    public class Startup
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _webHostEnvironment;

        /// <summary>Initializes a new instance of the <see cref="Startup"/> class.</summary>
        /// <param name="configuration"><see cref="IConfiguration"/></param>
        /// <param name="webHostEnvironment"><see cref="IWebHostEnvironment"/></param>
        public Startup(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _webHostEnvironment = webHostEnvironment ?? throw new ArgumentNullException(nameof(webHostEnvironment));
        }

        /// <summary>This method gets called by the runtime. Use this method to add services to the container.</summary>
        /// <param name="services"><see cref="IServiceCollection"/></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplication(_configuration);
            services.AddInfrastructure(_configuration);
            services
                .AddControllersWithViews()
                .AddJsonOptions(options => options.JsonSerializerOptions.IgnoreNullValues = true);
            services.AddSpaStaticFiles(configuration => { configuration.RootPath = "ClientApp/build"; });
            if (!_webHostEnvironment.IsProduction())
            {
                services.AddSwaggerExtension(_configuration);
            }
        }

        /// <summary>This method gets called by the runtime. Use this method to configure the HTTP request pipeline.</summary>
        /// <param name="app"><see cref="IApplicationBuilder"/></param>
        /// <param name="env"><see cref="IWebHostEnvironment"/></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwaggerExtension();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
    }
}