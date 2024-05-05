using Microsoft.EntityFrameworkCore;
using PackIT.Domain.Entities;
using PackIT.Domain.ValueObjects;
using PackIT.Infrastructure.Data.Config;

namespace PackIT.Infrastructure.Data.Contexts;

internal sealed class AppWriteDbContext(DbContextOptions<AppWriteDbContext> options): DbContext(options)
{
    public DbSet<PackingList> PackingLists { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var configuration = new WriteConfiguration();
        modelBuilder.ApplyConfiguration<PackingList>(configuration);
        modelBuilder.ApplyConfiguration<PackingItem>(configuration);

        modelBuilder.Entity<PackingList>().ToTable("PackingLists");
        modelBuilder.Entity<PackingItem>().ToTable("PackingItem");
    }
}
