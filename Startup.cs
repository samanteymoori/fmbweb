using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using FMB.Controllers;
using FMB.Model;
using FMB.Services;
using FMBPublic.Model;
using FMBPublic.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FMB
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            //var builder = new ConfigurationBuilder()
            //    .SetBasePath(env.ContentRootPath)
            //    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            //    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
            //    .AddEnvironmentVariables();
            //Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IFMBServices, FMBServices>();
            

            services.AddDistributedMemoryCache();
            services.AddSession();
            services.AddMemoryCache();
            // Add framework services.
            services.AddMvc();

            services.AddAuthentication(o => {
                o.DefaultScheme = SchemesNamesConst.UserAuthenticationDefaultScheme;
            })
      .AddScheme<UserAuthenticationOptions, UserAuthenticationHandler>(SchemesNamesConst.UserAuthenticationDefaultScheme, o => { });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseSession();
            app.UseStaticFiles();
            app.UseStatusCodePagesWithRedirects("/Landing/E{0}");
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Landing}/{action=Index}/{id?}");
            });
        }
    }
}
