using PackIT.Application.DTO.External;
using PackIT.Application.Services;
using PackIT.Domain.ValueObjects;

namespace PackIT.Infrastructure.Services;

internal sealed class WeatherService : IWeatherService
{
    public Task<WeatherDto> GetWeatherAsync(Localization localization)
    {
        return Task.FromResult(new WeatherDto(new Random().Next(-10, 45)));
    }
}
