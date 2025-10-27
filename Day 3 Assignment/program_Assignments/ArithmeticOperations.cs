using System;

class ArithmeticOperations
{
    public static void Execute()
    {
        Console.Write("Enter first number: ");
        int a = int.Parse(Console.ReadLine());
        Console.Write("Enter second number: ");
        int b = int.Parse(Console.ReadLine());

        Console.WriteLine($"\nAddition: {a + b}");
        Console.WriteLine($"Subtraction: {a - b}");
        Console.WriteLine($"Multiplication: {a * b}");
        Console.WriteLine($"Division: {(b != 0 ? (double)a / b : double.NaN)}");
        Console.WriteLine($"Modulus: {(b != 0 ? a % b : double.NaN)}");
        Console.ReadKey();
    }
}
