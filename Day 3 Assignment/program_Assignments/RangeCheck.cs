class RangeCheck
{
    public static void Execute()
    {
        Console.Write("Enter a number: ");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine(n >= 10 && n <= 50
            ? "Number lies between 10 and 50"
            : "Number is outside the range");
    }
}
