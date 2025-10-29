using System;
using TemperatureConverterLib; // Using your library

namespace TemperatureClientApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var converter = new TemperatureConverter();

            Console.WriteLine("=== Temperature Converter ===");

            double c = 25;
            double f = converter.CelsiusToFahrenheit(c);
            Console.WriteLine($"{c}°C = {f}°F");

            double f2 = 212;
            double c2 = converter.FahrenheitToCelsius(f2);
            Console.WriteLine($"{f2}°F = {c2}°C");

            // ❌ Try uncommenting this line to see the error:
            // TemperatureValidator v = new TemperatureValidator();
            // Error: 'TemperatureValidator' is inaccessible due to its protection level.

            Console.ReadLine();
        }
    }
}
