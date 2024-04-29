using PackIT.Shared.Abstraction.Exceptions;

namespace PackIT.Domain.Exceptions;

public class NegativePackingItemQuantityException : PackItException
{
    public NegativePackingItemQuantityException() : base("Packing item quantity must be greater than 0!")
    {
    }
}
