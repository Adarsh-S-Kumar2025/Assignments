using System;
using MathUtilities;

namespace MathUtilitiesTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Testing MathUtilities Library:\n");

            Console.Write("Enter a number: ");
            int num = int.Parse(Console.ReadLine());

            Console.WriteLine($"\nIs {num} even? {MathUtils.IsEven(num)}");
            Console.WriteLine($"Is {num} prime? {MathUtils.IsPrime(num)}");
            Console.WriteLine($"Factorial of {num} is {MathUtils.Factorial(num)}");
        }
    }
}
