using Charger.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Charger.WebAPI {

    public static class ConfigureServices {
        public static IServiceCollection AddWebAPIServices(this IServiceCollection services, IConfiguration configuration) {
            return services;
        }
    }

}
