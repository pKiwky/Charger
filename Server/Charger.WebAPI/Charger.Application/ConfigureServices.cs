using Charger.Application.Contracts.Commands;
using Charger.Application.Handlers.Commands;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Charger.Application {

    public static class ConfigureServices {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration) {
            services.AddScoped<IStationCommand, StationCommand>();

            return services;
        }
    }

}
