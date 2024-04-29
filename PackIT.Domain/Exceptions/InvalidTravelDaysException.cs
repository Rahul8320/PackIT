using PackIT.Shared.Abstraction.Exceptions;

namespace PackIT.Domain.Exceptions;

public class InvalidTravelDaysException(ushort days) : PackItException("Travel days must be between 0 and 100!")
{
    public ushort Days { get; } = days;
}
