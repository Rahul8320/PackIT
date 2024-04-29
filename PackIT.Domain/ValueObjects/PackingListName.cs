using PackIT.Domain.Exceptions;

namespace PackIT.Domain.ValueObjects;

/// <summary>
/// Represents packing list name value object
/// </summary>
public record PackingListName
{
    /// <summary>
    /// Get the value of packing list name
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// Create a new instance of packing list name value object.
    /// </summary>
    /// <param name="value">Value of this object</param>
    /// <exception cref="EmptyPackingListNameException">Exception for empty value</exception>
    public PackingListName(string value)
    {
        // Check for null or white space
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new EmptyPackingListNameException();
        }

        Value = value;
    }

    /// <summary>
    /// Convert string into value object
    /// </summary>
    /// <param name="name">The name or the value</param>
    public static implicit operator PackingListName(string name) => new(name);

    /// <summary>
    /// Convert value object to string
    /// </summary>
    /// <param name="name">The value object</param>
    public static implicit operator string(PackingListName name) => name.Value;
}
