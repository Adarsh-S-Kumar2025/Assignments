using System;

namespace AssignmentApp
{
    public class ReverseNumber
    {
        public void Execute()
        {
            Console.Write("Enter a number: ");
            int num = Convert.ToInt32(Console.ReadLine());
            int rev = 0;
            while (num > 0)
            {
                rev = rev * 10 + num % 10;
                num /= 10;
            }
            Console.WriteLine("Reversed number: " + rev);
        }
    }
}
