class EvenOddCheck
{
    public static void Execute()
    {
        Console.Write("Enter a number: ");
        int n = int.Parse(Console.ReadLine());
        string result = (n % 2 == 0) ? "Even" : "Odd";
        Console.WriteLine($"{n} is {result}");
    }
}
