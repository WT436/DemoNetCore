using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using B5_ApiTutorial.ConfigOptions;
using B5_ApiTutorial.Installer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace B5_ApiTutorial
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var settingService = typeof(Startup).Assembly.ExportedTypes.Where(x =>
                                                                                  typeof(IInstaller).IsAssignableFrom(x)
                                                                                  && !x.IsInterface
                                                                                  && !x.IsAbstract)
                                                                       .Select(Activator.CreateInstance)
                                                                       .Cast<IInstaller>()
                                                                       .ToList();
            settingService.ForEach(ins => ins.InstallerServices(services, Configuration));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseAuthentication();

            var swaggerConfigStartup = new SwaggerConfigStartup();
            Configuration.GetSection(nameof(SwaggerConfigStartup)).Bind(swaggerConfigStartup);
            app.UseSwagger(op => { op.RouteTemplate = swaggerConfigStartup.JsonRoute; });

            app.UseSwaggerUI(op =>
            {
                op.SwaggerEndpoint(swaggerConfigStartup.UIEndpoint, swaggerConfigStartup.Description);
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
