class RefSwap
{
    public static void Swap(ref int a, ref int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }

    public static void Execute()
    {
        int x = 10, y = 20;
        Console.WriteLine($"Before Swap: x = {x}, y = {y}");
        Swap(ref x, ref y);
        Console.WriteLine($"After Swap: x = {x}, y = {y}");
    }
}
