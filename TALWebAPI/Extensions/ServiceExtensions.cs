using DataModel.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TALWebAPI.Persistence.Interfaces;
using TALWebAPI.Persistence.Repositories;

namespace TALWebAPI.Extensions
{
    public static class ServiceExtensions
    {
        /// <summary>
        /// Adds the custom MVC.
        /// Add filters to the project.
        /// Setting up the model based on the return type.
        /// Fluent validation model registration
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns></returns>
        public static IServiceCollection AddCustomMvc(this IServiceCollection services)
        {
            //Creating Authorization policy to globally apply to all actions
            //var authorizationPolicy = new AuthorizationPolicyBuilder()
            //    .RequireAuthenticatedUser()
            //    .Build();
            services
                .AddMvc(options =>
                {
                    // Adds the possible response types for each actions.
                    options.Filters.Add(new ProducesResponseTypeAttribute(typeof(ValidationErrorModel),
                        StatusCodes.Status400BadRequest));
                    options.Filters.Add(new ProducesResponseTypeAttribute(typeof(ErrorModel),
                        StatusCodes.Status401Unauthorized));
                    options.Filters.Add(new ProducesResponseTypeAttribute(typeof(ErrorModel),
                        StatusCodes.Status406NotAcceptable));
                    options.Filters.Add(new ProducesResponseTypeAttribute(typeof(ErrorModel),
                        StatusCodes.Status500InternalServerError));
                    options.Filters.Add(new ProducesResponseTypeAttribute(typeof(ErrorModel),
                        StatusCodes.Status404NotFound));
                    options.Filters.Add(typeof(RequestLoggingActionFilter));
                    options.Filters.Add(typeof(ValidationActionFilter));
                                        
                    options.ReturnHttpNotAcceptable = true;
                })
                .AddXmlSerializerFormatters()
                .SetCompatibilityVersion(CompatibilityVersion.Latest);
            return services;
        }

        /// <summary>Adds the swagger configuration.</summary>
        /// <param name="services">The services.</param>
        /// <returns>the services</returns>
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(options =>
            {
                // Set the comments path for the Swagger JSON and UI.
                var xmlFiles = Directory.GetFiles(AppContext.BaseDirectory, "*.xml", SearchOption.TopDirectoryOnly).ToList();
                xmlFiles.ForEach(x => options.IncludeXmlComments(x));

                options.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter JWT with Bearer into field",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme()
                        {
                            Reference = new OpenApiReference() { Type = ReferenceType.SecurityScheme, Id = "Bearer"},
                            Name = "Bearer",
                            In = ParameterLocation.Header
                        },
                        new List<string>()
                    }
                });

            });
            return services;
        }

        /// <summary>Adds the unit of work.</summary>
        /// <param name="services">The services.</param>
        public static void AddUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        /// <summary>Adds the SQL context.</summary>
        /// <param name="services">The services.</param>
        /// <param name="config">The configuration.</param>
        /// <returns></returns>
        public static IServiceCollection AddSqlContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config["ConnectionStrings:TALDB"];
            services.AddDbContext<TALDBContext>(options => options.UseSqlServer(connectionString, sqlServerOptionsAction: sqlOptions =>
            {
                sqlOptions.CommandTimeout(300);
                sqlOptions.EnableRetryOnFailure(
                    3,
                    TimeSpan.FromSeconds(30),
                    null);
            }));
            return services;
        }
    }
}
