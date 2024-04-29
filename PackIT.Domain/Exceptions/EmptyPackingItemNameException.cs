using PackIT.Shared.Abstraction.Exceptions;

namespace PackIT.Domain.Exceptions;

public class EmptyPackingItemNameException : PackItException
{
    public EmptyPackingItemNameException() : base("Packing item name can not be empty!")
    {
    }
}
