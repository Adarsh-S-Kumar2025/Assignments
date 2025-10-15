using System;

namespace AssignmentApp
{
    public class TaxCalculation
    {
        public void Execute()
        {
            Console.Write("Enter amount: ");
            double amount = Convert.ToDouble(Console.ReadLine());
            double tax = amount switch
            {
                < 10000 => amount * 0.05,
                <= 15000 => amount * 0.075,
                <= 20000 => amount * 0.10,
                <= 25000 => amount * 0.125,
                _ => amount * 0.15
            };
            Console.WriteLine($"Tax to be paid: ₹{tax:F2}");
        }
    }
}
