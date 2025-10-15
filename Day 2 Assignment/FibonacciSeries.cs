using System;

namespace AssignmentApp
{
    public class FibonacciSeries
    {
        public void Execute()
        {
            Console.Write("Enter number of terms: ");
            int n = Convert.ToInt32(Console.ReadLine());
            int a = 0, b = 1;

            for (int i = 0; i < n; i++)
            {
                Console.Write(a + " ");
                int temp = a + b;
                a = b;
                b = temp;
            }
            Console.WriteLine();
        }
    }
}
