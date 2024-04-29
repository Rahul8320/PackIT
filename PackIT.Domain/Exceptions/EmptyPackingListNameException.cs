using PackIT.Shared.Abstraction.Exceptions;

namespace PackIT.Domain.Exceptions;

/// <summary>
/// Represents empty packing list name exception class
/// </summary>
public class EmptyPackingListNameException : PackItException
{
    /// <summary>
    /// Initialize new instance of empty packing list name exception object
    /// </summary>
    public EmptyPackingListNameException() : base(message: "Packing list name cannot be empty!")
    {
    }
}
