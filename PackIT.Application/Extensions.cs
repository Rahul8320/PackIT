using Microsoft.Extensions.DependencyInjection;
using PackIT.Domain.Factories;
using PackIT.Shared.Commands;
using PackIT.Shared.Queries;

namespace PackIT.Application;

public static class Extensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddCommands();

        services.AddSingleton<IPackingListFactory, PackingListFactory>();
        services.Scan(b => b.FromAssemblies(typeof(IPackingListFactory).Assembly)
            .AddClasses(c => c.AssignableTo<IPackingListFactory>())
            .AsImplementedInterfaces()
            .WithSingletonLifetime());

        return services;
    }
}
