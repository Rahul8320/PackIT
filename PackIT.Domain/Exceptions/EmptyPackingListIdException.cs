using PackIT.Shared.Abstraction.Exceptions;

namespace PackIT.Domain.Exceptions;

public class EmptyPackingListIdException : PackItException
{
    public EmptyPackingListIdException() : base("Packing list ID cannot be empty!")
    {
    }
}
