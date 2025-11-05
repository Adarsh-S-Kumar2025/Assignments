class SumAndAverage
{
    public static void GetSumAndAverage(int a, int b, out int sum, out double avg)
    {
        sum = a + b;
        avg = sum / 2.0;
    }

    public static void Execute()
    {
        GetSumAndAverage(10, 20, out int sum, out double avg);
        Console.WriteLine($"Sum = {sum}, Average = {avg}");
    }
}
