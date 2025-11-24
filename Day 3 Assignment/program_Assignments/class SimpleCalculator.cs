class SimpleCalculator
{
    public static void Execute()
    {
        Console.Write("Enter first number: ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("Enter operator (+, -, *, /, %): ");
        char op = char.Parse(Console.ReadLine());
        Console.Write("Enter second number: ");
        double b = double.Parse(Console.ReadLine());

        double result = op switch
        {
            '+' => a + b,
            '-' => a - b,
            '*' => a * b,
            '/' => b != 0 ? a / b : double.NaN,
            '%' => b != 0 ? a % b : double.NaN,
            _ => double.NaN
        };
        Console.WriteLine($"Result: {result}");
    }
}
