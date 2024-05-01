using PackIT.Application.Exceptions;
using PackIT.Domain.Repositories;
using PackIT.Shared.Abstraction.Commands;

namespace PackIT.Application.Commands.Handlers;

internal sealed class RemovePackingItemHandler(IPackingListRepository listRepository) : ICommandHandler<RemovePackingItem>
{
    public async Task HandleAsync(RemovePackingItem command)
    {
        var packingList = await listRepository.GetAsync(command.PackingListId);

        if(packingList is null)
        {
            throw new PackingListNotFoundException(command.PackingListId);
        }

        packingList.RemovePackingItem(command.Name);

        await listRepository.UpdateAsync(packingList);
    }
}
