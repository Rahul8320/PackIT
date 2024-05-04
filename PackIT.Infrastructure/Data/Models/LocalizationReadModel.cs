namespace PackIT.Infrastructure.Data.Models;

internal class LocalizationReadModel
{
    public string Country { get; set; } = default!;
    public string City { get; set; } = default!;

    public static LocalizationReadModel Create(string value)
    {
        var splitLocalization = value.Split(',');

        return new LocalizationReadModel 
        {
            City = splitLocalization.First(), 
            Country = splitLocalization.Last() 
        };
    }

    public override string ToString()
    {
        return $"{City},{Country}";
    }
}
