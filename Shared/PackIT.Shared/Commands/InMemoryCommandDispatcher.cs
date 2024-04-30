using Microsoft.Extensions.DependencyInjection;
using PackIT.Shared.Abstraction.Commands;

namespace PackIT.Shared.Commands;

internal sealed class InMemoryCommandDispatcher(IServiceProvider serviceProvider) : ICommandDispatcher
{

    public async Task DispatchAsync<TCommand>(TCommand command) where TCommand : class, ICommand
    {
        using var scope = serviceProvider.CreateScope();
        var handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<TCommand>>();

        await handler.HandleAsync(command);
    }
}
