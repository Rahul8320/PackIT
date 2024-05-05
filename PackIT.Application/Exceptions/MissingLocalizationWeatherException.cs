using PackIT.Domain.ValueObjects;
using PackIT.Shared.Abstraction.Exceptions;

namespace PackIT.Application.Exceptions;

public class MissingLocalizationWeatherException(Localization localization) 
    : PackItException($"Couldn't fetch weather data for localization '{localization.Country}/{localization.City}'!")
{
    public Localization Localization { get; } = localization;
}
