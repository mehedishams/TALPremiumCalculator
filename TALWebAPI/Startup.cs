using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;
using TALWebAPI.Extensions;

namespace TALWebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// 
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddCustomMvc();
            services.AddControllers();
            services.AddSqlContext(Configuration);
            services.AddCustomServices();
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddMvcCore().AddApiExplorer();
            services.AddSwaggerGen(option =>            // Register the Swagger generator, defining 1 or more Swagger documents.
            {
                option.SwaggerDoc("v1", new OpenApiInfo { Title = "TAL Premium Calculator API", Version = "v1" });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                option.IncludeXmlComments(xmlPath);
            });
            services.AddApplicationServices();
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else app.UseHsts();     // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.

            app.UseSwagger(option => option.SerializeAsV2 = true);  // Inserting Swagger middleware here - At this point, you can spin up your application and view the generated Swagger JSON at "/swagger/v1/swagger.json.".
            app.UseSwaggerUI(option =>                              // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            {
                option.SwaggerEndpoint("/swagger/v1/swagger.json", "TAL Premium Calculator API");
            });

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            
            app.UseCors("CorsPolicy");
            app.UseEndpoints(e => e.MapControllers());
            app.UseHttpsRedirection();
        }
    }
}
