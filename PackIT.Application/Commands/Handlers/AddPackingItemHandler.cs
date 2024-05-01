using PackIT.Application.Exceptions;
using PackIT.Domain.Repositories;
using PackIT.Domain.ValueObjects;
using PackIT.Shared.Abstraction.Commands;

namespace PackIT.Application.Commands.Handlers;

internal sealed class AddPackingItemHandler(IPackingListRepository listRepository) : ICommandHandler<AddPackingItem>
{
    public async Task HandleAsync(AddPackingItem command)
    {
        var packingList = await listRepository.GetAsync(command.PackingListId);

        if(packingList is null)
        {
            throw new PackingListNotFoundException(command.PackingListId);
        }

        var packingItem = new PackingItem(command.Name, command.Quantity);
        packingList.AddPackingItem(packingItem);

        await listRepository.UpdateAsync(packingList);
    }
}
