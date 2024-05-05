using Microsoft.EntityFrameworkCore;
using PackIT.Application.Services;
using PackIT.Infrastructure.Data.Contexts;
using PackIT.Infrastructure.Data.Models;

namespace PackIT.Infrastructure.Data.Services;

internal sealed class SqlitePackingListReadService(AppReadDbContext readDbContext) : IPackingListReadService
{
    private readonly DbSet<PackingListReadModel> _packingList = readDbContext.PackingLists;

    public Task<bool> ExistsByNameAsync(string name)
    {
        return _packingList.AnyAsync(pl => pl.Name == name);
    }
}
