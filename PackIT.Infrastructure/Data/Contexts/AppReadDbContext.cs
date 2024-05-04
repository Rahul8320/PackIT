using Microsoft.EntityFrameworkCore;
using PackIT.Infrastructure.Data.Config;
using PackIT.Infrastructure.Data.Models;

namespace PackIT.Infrastructure.Data.Contexts;

internal sealed class AppReadDbContext(DbContextOptions<AppReadDbContext> options) : DbContext(options)
{
    public DbSet<PackingListReadModel> PackingLists { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var configuration = new ReadConfiguration();
        modelBuilder.ApplyConfiguration<PackingListReadModel>(configuration);
        modelBuilder.ApplyConfiguration<PackingItemReadModel>(configuration);

        base.OnModelCreating(modelBuilder);
    }
}
