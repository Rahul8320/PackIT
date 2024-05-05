using System.ComponentModel.DataAnnotations.Schema;

namespace PackIT.Infrastructure.Data.Models;

[Table("PackingItem")]
internal class PackingItemReadModel
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public uint Quantity { get; set; }
    public bool IsPacked { get; set; }

    public PackingListReadModel PackingList { get; set; } = default!;
}
