using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PackIT.Application.Services;
using PackIT.Domain.Repositories;
using PackIT.Infrastructure.Data.Contexts;
using PackIT.Infrastructure.Data.Services;
using PackIT.Infrastructure.Repositories;

namespace PackIT.Infrastructure.Data;

internal static class Extensions
{
    public static IServiceCollection AddSqliteDatabase(this IServiceCollection services, IConfiguration  configuration)
    {
        services.AddScoped<IPackingListRepository, SqlitePackingListRepository>();
        services.AddScoped<IPackingListReadService, SqlitePackingListReadService>();

        var connectionString = configuration.GetConnectionString("Default");

        services.AddDbContext<AppReadDbContext>(option => option.UseSqlite(connectionString));
        services.AddDbContext<AppWriteDbContext>(option => option.UseSqlite(connectionString));

        return services;
    }
}
