using PackIT.Shared.Abstraction.Exceptions;

namespace PackIT.Domain.Exceptions;

public class PackingItemNotFoundException(string itemName) : PackItException($"Packing item '{itemName}' was not found!")
{
    public string ItemName { get; } = itemName;
}
