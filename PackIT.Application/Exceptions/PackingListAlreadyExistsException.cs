using PackIT.Shared.Abstraction.Exceptions;

namespace PackIT.Application.Exceptions;

public class PackingListAlreadyExistsException(string name) : PackItException($"Packing list with name: {name} already exists!")
{
    public string Name { get; } = name;
}
