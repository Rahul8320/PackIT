namespace PackIT.Application.DTO;

public class LocalizationDto(string country, string city)
{
    public string Country { get; set; } = country;
    public string City { get; set; } = city;
}
