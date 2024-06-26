﻿using PackIT.Domain.Exceptions;

namespace PackIT.Domain.ValueObjects;

public class Temperature
{
    public double Value { get; }

    public Temperature(double value)
    {
        if (value is < -100 or > 100)
        {
            throw new InvalidTemperatureException(value);
        }

        Value = value;
    }

    public static implicit operator Temperature(double temp) => new(temp);

    public static implicit operator double(Temperature temp) => temp.Value;
}
