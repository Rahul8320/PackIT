using Microsoft.Extensions.DependencyInjection;
using PackIT.Shared.Abstraction.Queries;

namespace PackIT.Shared.Queries;

public class InMemoryQueryDispatcher(IServiceProvider serviceProvider) : IQueryDispatcher
{
    public async Task<TResult> QueryAsync<TResult>(IQuery<TResult> query)
    {
        using var scope = serviceProvider.CreateScope();
        var handlerType = typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResult));
        var handler = scope.ServiceProvider.GetRequiredService(handlerType);

        return await (Task<TResult>) handlerType.GetMethod(nameof(IQueryHandler<IQuery<TResult>, TResult>.HandleAsync))?.Invoke(handler, new[] {query})!;
    }
}
