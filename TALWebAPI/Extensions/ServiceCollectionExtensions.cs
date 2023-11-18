using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TALWebAPI.Persistence.Interfaces;
using TALWebAPI.Persistence.Repositories;

namespace TALWebAPI.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IRatingRepository, RatingRepository>();
            return services;
        }
    }
}
