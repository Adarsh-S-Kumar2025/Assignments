namespace TemperatureConverterLib
{
    // Internal class – cannot be used outside this DLL
    internal class TemperatureValidator
    {
        public static bool IsValid(double celsius)
        {
            return celsius >= -273.15 && celsius <= 5500;
        }
    }
}
