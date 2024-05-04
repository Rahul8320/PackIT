using Microsoft.EntityFrameworkCore;
using PackIT.Application.DTO;
using PackIT.Application.Queries;
using PackIT.Infrastructure.Data.Contexts;
using PackIT.Infrastructure.Data.Models;
using PackIT.Shared.Abstraction.Queries;

namespace PackIT.Infrastructure.Queries.Handler;

internal sealed class SearchPackingListHandler(AppReadDbContext context) : IQueryHandler<SearchPackingList, IEnumerable<PackingListDto>>
{
    private readonly DbSet<PackingListReadModel> _packingLists = context.PackingLists;

    public async Task<IEnumerable<PackingListDto>> HandleAsync(SearchPackingList query)
    {
        var dbQuery = _packingLists
            .Include(pl => pl.Items)
            .AsQueryable();

        if(string.IsNullOrEmpty(query.SearchPharse) == false)
        {
            dbQuery = dbQuery.Where(pl => pl.Name.Contains($"%{query.SearchPharse}%"));
        }

        return await dbQuery.Select(pl => pl.ToDto()).AsNoTracking().ToListAsync();
    }
}
