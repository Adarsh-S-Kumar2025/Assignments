using System;

namespace TemperatureConverterLib
{
    public class TemperatureConverter
    {
        public double CelsiusToFahrenheit(double celsius)
        {
            if (!TemperatureValidator.IsValid(celsius))
                throw new ArgumentOutOfRangeException(nameof(celsius),
                    "Temperature is out of valid range (-273.15°C to 5500°C).");

            return (celsius * 9 / 5) + 32;
        }

        public double FahrenheitToCelsius(double fahrenheit)
        {
            double celsius = (fahrenheit - 32) * 5 / 9;

            if (!TemperatureValidator.IsValid(celsius))
                throw new ArgumentOutOfRangeException(nameof(fahrenheit),
                    "Converted temperature is out of valid range (-273.15°C to 5500°C).");

            return celsius;
        }
    }
}
