using PackIT.Application.Exceptions;
using PackIT.Domain.Repositories;
using PackIT.Shared.Abstraction.Commands;

namespace PackIT.Application.Commands.Handlers;

internal sealed class PackItemHandler(IPackingListRepository listRepository) : ICommandHandler<PackItem>
{
    public async Task HandleAsync(PackItem command)
    {
        var packingList = await listRepository.GetAsync(command.PackingListId);

        if (packingList is null)
        {
            throw new PackingListNotFoundException(command.PackingListId);
        }

        packingList.PackItem(command.Name);

        await listRepository.UpdateAsync(packingList);
    }
}
