using PackIT.Application.Exceptions;
using PackIT.Domain.Repositories;
using PackIT.Shared.Abstraction.Commands;

namespace PackIT.Application.Commands.Handlers;

internal sealed class DeletePackingListHandler(IPackingListRepository listRepository) : ICommandHandler<DeletePackingList>
{
    public async Task HandleAsync(DeletePackingList command)
    {
        var packingList = await listRepository.GetAsync(command.Id);
        
        if (packingList is null)
        {
            throw new PackingListNotFoundException(command.Id);
        }

        await listRepository.DeleteAsync(packingList);
    }
}
