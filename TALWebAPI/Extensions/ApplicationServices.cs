using MediatR;
using Microsoft.Extensions.DependencyInjection;
using TALWebAPI.App.Rating.Queries;

namespace TALWebAPI.Extensions
{
    public static class ApplicationServices
    {
        /// <summary>
        /// Adds the Mediatr services.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns></returns>
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(typeof(RatingQueryHandler));
            return services;
        }
    }
}
