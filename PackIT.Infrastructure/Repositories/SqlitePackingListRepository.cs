using Microsoft.EntityFrameworkCore;
using PackIT.Application.Exceptions;
using PackIT.Domain.Entities;
using PackIT.Domain.Repositories;
using PackIT.Domain.ValueObjects;
using PackIT.Infrastructure.Data.Contexts;

namespace PackIT.Infrastructure.Repositories;

internal sealed class SqlitePackingListRepository(AppWriteDbContext writeDbContext) : IPackingListRepository
{
    private readonly DbSet<PackingList> _packingLists = writeDbContext.PackingLists;

    public async Task AddAsync(PackingList packingList)
    {
        await _packingLists.AddAsync(packingList);
        await writeDbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(PackingList packingList)
    {
        _packingLists.Remove(packingList);
        await writeDbContext.SaveChangesAsync();
    }

    public async Task<PackingList> GetAsync(PackingListId id)
    {
        var packingList = await _packingLists.Include("_items").SingleOrDefaultAsync(pl => pl.Id == id);

        return packingList is null ? throw new PackingListNotFoundException(id) : packingList;
    }

    public async Task UpdateAsync(PackingList packingList)
    {
        _packingLists.Update(packingList);
        await writeDbContext.SaveChangesAsync();
    }
}
