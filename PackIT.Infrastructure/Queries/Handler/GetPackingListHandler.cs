using Microsoft.EntityFrameworkCore;
using PackIT.Application.DTO;
using PackIT.Application.Exceptions;
using PackIT.Application.Queries;
using PackIT.Infrastructure.Data.Contexts;
using PackIT.Infrastructure.Data.Models;
using PackIT.Shared.Abstraction.Queries;

namespace PackIT.Infrastructure.Queries.Handler;

internal sealed class GetPackingListHandler(AppReadDbContext context) : IQueryHandler<GetPackingList, PackingListDto>
{
    private readonly DbSet<PackingListReadModel> _packingLists = context.PackingLists;

    public async Task<PackingListDto> HandleAsync(GetPackingList query)
    {
        var packingList = await _packingLists
            .Include(pl => pl.Items)
            .Where(pl => pl.Id == query.Id)
            //.Select(pl => pl.ToDto())
            .AsNoTracking()
            .SingleOrDefaultAsync();

        return packingList is null ? throw new PackingListNotFoundException(query.Id) : packingList.ToDto();
    }
}
