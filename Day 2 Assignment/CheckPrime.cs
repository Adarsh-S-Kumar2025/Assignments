using System;

namespace AssignmentApp
{
    public class CheckPrime
    {
        public void Execute()
        {
            Console.Write("Enter a number: ");
            int num = Convert.ToInt32(Console.ReadLine());
            bool isPrime = num > 1;
            for (int i = 2; i <= Math.Sqrt(num); i++)
            {
                if (num % i == 0)
                {
                    isPrime = false;
                    break;
                }
            }
            Console.WriteLine(isPrime ? "Prime number" : "Not a prime number");
        }
    }
}
