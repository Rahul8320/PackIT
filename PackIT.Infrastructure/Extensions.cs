using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PackIT.Application.Services;
using PackIT.Infrastructure.Data;
using PackIT.Infrastructure.Services;
using PackIT.Shared.Queries;

namespace PackIT.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSqliteDatabase(configuration);
        services.AddQueries();

        services.AddSingleton<IWeatherService, WeatherService>();

        return services;
    }
}
