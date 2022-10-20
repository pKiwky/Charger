using Charger.Application.Contracts.Commands;
using Charger.Application.Contracts.Queries;
using Charger.Application.Handlers.Commands;
using Charger.Application.Handlers.Queries;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Charger.Application {

    public static class ConfigureServices {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration) {
            services.AddScoped<IStationCommand, StationCommand>();
            services.AddScoped<IStationQuery, StationQuery>();

            services.AddScoped<ICarCommand, CarCommand>();
            services.AddScoped<ICarQuery, CarQuery>();

            services.AddScoped<IAuthenticationCommand, AuthenticationCommand>();
            services.AddScoped<IAuthenticationQuery, AuthenticationQuery>();

            services.AddScoped<IJwtQueryService, JwtQueryService>();

            return services;
        }
    }

}
