using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using B4_SwaggerConfiguration.ConfigStartup;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace B4_SwaggerConfiguration
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
            services.AddControllers();

            services.AddSwaggerGen(x => {
                x.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo{ Title = "Nam DZ", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            var swaggerConfigStartup = new SwaggerConfigStartup();
            Configuration.GetSection(nameof(SwaggerConfigStartup)).Bind(swaggerConfigStartup);

            app.UseSwagger(op => { op.RouteTemplate = swaggerConfigStartup.JsonRoute; });

            app.UseSwaggerUI(op =>
            {
                op.SwaggerEndpoint(swaggerConfigStartup.UIEndpoint, swaggerConfigStartup.Description);
            });




            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
