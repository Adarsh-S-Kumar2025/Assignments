class CompareIntegers
{
    public static void Execute()
    {
        Console.Write("Enter first integer: ");
        int x = int.Parse(Console.ReadLine());
        Console.Write("Enter second integer: ");
        int y = int.Parse(Console.ReadLine());

        Console.WriteLine($"{x} == {y} : {x == y}");
        Console.WriteLine($"{x} != {y} : {x != y}");
        Console.WriteLine($"{x} > {y} : {x > y}");
        Console.WriteLine($"{x} < {y} : {x < y}");
        Console.WriteLine($"Both positive? : {(x > 0 && y > 0)}");
        Console.WriteLine($"At least one is positive? : {(x > 0 || y > 0)}");
    }
}

