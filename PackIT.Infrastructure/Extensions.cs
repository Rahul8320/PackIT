using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PackIT.Infrastructure.Data;
using PackIT.Shared.Queries;

namespace PackIT.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddQueries();
        services.AddSqliteDatabase(configuration);

        return services;
    }
}
