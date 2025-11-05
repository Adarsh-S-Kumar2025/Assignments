using System;

namespace SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Simple Calculator with Exception Handling ===\n");

            try
            {
                Console.Write("Enter first number: ");
                double num1 = Convert.ToDouble(Console.ReadLine());

                Console.Write("Enter second number: ");
                double num2 = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("\nSelect Operation: ");
                Console.WriteLine("1. Add");
                Console.WriteLine("2. Subtract");
                Console.WriteLine("3. Multiply");
                Console.WriteLine("4. Divide");
                Console.Write("Enter your choice (1-4): ");
                int choice = Convert.ToInt32(Console.ReadLine());

                double result = 0;

                switch (choice)
                {
                    case 1:
                        result = num1 + num2;
                        Console.WriteLine($"Result: {result}");
                        break;
                    case 2:
                        result = num1 - num2;
                        Console.WriteLine($"Result: {result}");
                        break;
                    case 3:
                        result = num1 * num2;
                        Console.WriteLine($"Result: {result}");
                        break;
                    case 4:
                        result = num1 / num2;
                        Console.WriteLine($"Result: {result}");
                        break;
                    default:
                        Console.WriteLine("Invalid operation selected.");
                        break;
                }
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("❌ Error: Cannot divide by zero.");
                Console.WriteLine($"[LOG] {ex.Message}");
            }
            catch (FormatException ex)
            {
                Console.WriteLine("❌ Error: Invalid number format. Please enter numeric values.");
                Console.WriteLine($"[LOG] {ex.Message}");
            }
            catch (OverflowException ex)
            {
                Console.WriteLine("❌ Error: Number too large or too small to process.");
                Console.WriteLine($"[LOG] {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ An unexpected error occurred.");
                Console.WriteLine($"[LOG] {ex.Message}");
            }
            finally
            {
                Console.WriteLine("\nOperation complete. Thank you for using the calculator!");
            }
        }
    }
}
