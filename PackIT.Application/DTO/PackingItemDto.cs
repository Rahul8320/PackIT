namespace PackIT.Application.DTO;

public class PackingItemDto(string name, uint quantity, bool isPacked)
{
    public string Name{ get; set; } = name;
    public uint Quantity { get; set; } = quantity;
    public bool IsPacked { get; set; } = isPacked;
}
