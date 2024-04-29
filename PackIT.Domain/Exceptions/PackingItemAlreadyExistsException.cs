using PackIT.Shared.Abstraction.Exceptions;

namespace PackIT.Domain.Exceptions;

public class PackingItemAlreadyExistsException(string packingListName, string packingItemName)
    : PackItException($"Packing list: '{packingListName}' already defined item '{packingItemName}'")
{
    public string PackingListName { get; } = packingListName;
    public string packingItemName { get; } = packingItemName;
}
