using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PackIT.Infrastructure.Data.Contexts;

namespace PackIT.Infrastructure.Data;

internal static class Extensions
{
    public static IServiceCollection AddSqlite(this IServiceCollection services, IConfiguration  configuration)
    {
        var connectionString = configuration.GetConnectionString("Default");

        services.AddDbContext<AppReadDbContext>(option => option.UseSqlite(connectionString));
        services.AddDbContext<AppWriteDbContext>(option => option.UseSqlite(connectionString));

        return services;
    }
}
