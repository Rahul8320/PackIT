using PackIT.Shared.Abstraction.Exceptions;

namespace PackIT.Domain.Exceptions;

public class InvalidTemperatureException(double tempereture) : PackItException("Tempareture must be between -100 to 100!")
{
    public double Tempereture { get; } = tempereture;
}
