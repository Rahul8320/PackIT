namespace PackIT.Infrastructure.Data.Models;

internal class PackingListReadModel
{
    public Guid Id { get; set; }
    public int Version { get; set; }
    public string Name { get; set; } = string.Empty;
    public LocalizationReadModel Localization { get; set; } = default!;
    public ICollection<PackingItemReadModel> Items { get; set; } = default!;
}
