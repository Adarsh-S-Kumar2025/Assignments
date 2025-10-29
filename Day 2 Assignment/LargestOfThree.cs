using System;

namespace AssignmentApp
{
    public class LargestOfThree
    {
        public void Execute()
        {
            Console.Write("Enter three numbers: ");
            int a = Convert.ToInt32(Console.ReadLine());
            int b = Convert.ToInt32(Console.ReadLine());
            int c = Convert.ToInt32(Console.ReadLine());
            int largest = Math.Max(a, Math.Max(b, c));
            Console.WriteLine("Largest number is: " + largest);
        }
    }
}
