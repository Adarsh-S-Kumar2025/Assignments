class ArrayMinMax
{
    public static void FindMaxMin(int[] arr, out int max, out int min)
    {
        max = arr[0];
        min = arr[0];
        foreach (int val in arr)
        {
            if (val > max) max = val;
            if (val < min) min = val;
        }
    }

    public static void Execute()
    {
        int[] numbers = { 3, 9, 2, 15, 6 ,7,99};
        FindMaxMin(numbers, out int max, out int min);
        Console.WriteLine($"Max = {max}, Min = {min}");
    }
}
