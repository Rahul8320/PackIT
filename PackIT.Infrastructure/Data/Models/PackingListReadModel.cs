using System.ComponentModel.DataAnnotations.Schema;

namespace PackIT.Infrastructure.Data.Models;

[Table("PackingLists")]
internal class PackingListReadModel
{
    public Guid Id { get; set; }
    public int Version { get; set; }
    public string Name { get; set; } = string.Empty;
    public LocalizationReadModel Localization { get; set; } = default!;
    public ICollection<PackingItemReadModel> Items { get; set; } = default!;
}
