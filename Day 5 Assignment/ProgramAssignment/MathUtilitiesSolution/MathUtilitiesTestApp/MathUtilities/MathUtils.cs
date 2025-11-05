using System;

namespace MathUtilities
{
    public static class MathUtils
    {
        // Method to check if a number is even
        public static bool IsEven(int number)
        {
            return number % 2 == 0;
        }

        // Method to check if a number is prime
        public static bool IsPrime(int number)
        {
            if (number <= 1)
                return false;

            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                    return false;
            }

            return true;
        }

        // Method to calculate factorial
        public static long Factorial(int number)
        {
            if (number < 0)
                throw new ArgumentException("Factorial is not defined for negative numbers.");

            long result = 1;
            for (int i = 1; i <= number; i++)
            {
                result *= i;
            }
            return result;
        }
    }
}
