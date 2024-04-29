namespace PackIT.Domain.ValueObjects;

/// <summary>
/// Represents packing list localization value object
/// </summary>
/// <param name="City">The city of the localization</param>
/// <param name="Country">The country of the localization</param>
public record Localization(string City, string Country)
{
    /// <summary>
    /// Create a new instance of packing list localization
    /// </summary>
    /// <param name="value">The value </param>
    /// <returns>Returns new packing list localization object</returns>
    public static Localization Create(string value)
    {
        var spiltLocalization = value.Split(',');
        return new Localization(spiltLocalization.First(), spiltLocalization.Last());
    }

    /// <summary>
    /// Convert packing list localization to string
    /// </summary>
    /// <returns>Return string value</returns>
    public override string ToString() => $"{City},{Country}";
}
