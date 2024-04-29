using PackIT.Shared.Abstraction.Exceptions;

namespace PackIT.Domain.Exceptions;

public class InvalidPackingItemQuantityException : PackItException
{
    public InvalidPackingItemQuantityException() : base("Packing item quantity must be greater than 0!")
    {
    }
}
