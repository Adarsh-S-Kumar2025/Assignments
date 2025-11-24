using System;
using BankingApp.Models;
using BankingApp.Operations;

namespace BankingApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AccountOperations accountOps = new AccountOperations();

            // Seed initial data (run once)
            if (false) // change to true for initial insert
            {
                accountOps.Add(new Customer { FullName = "John Smith", Email = "john.smith@email.com", PhoneNumber = "-857", DateOfBirth = new DateTime(1987, 4, 12), Address = "123 Main St, New York, USA", CreatedDate = new DateTime(2025, 1, 1) });
                accountOps.Add(new Customer { FullName = "Maria Gonzalez", Email = "maria.gonzalez@gmail.com", PhoneNumber = "-1601", DateOfBirth = new DateTime(1990, 8, 25), Address = "45 Calle Mayor, Madrid, Spain", CreatedDate = new DateTime(2025, 2, 15) });
                accountOps.Add(new Customer { FullName = "Liam O’Connor", Email = "liam.oconnor@outlook.com", PhoneNumber = "-907779", DateOfBirth = new DateTime(1985, 11, 3), Address = "89 Abbey Rd, London, UK", CreatedDate = new DateTime(2025, 3, 10) });
                accountOps.Add(new Customer { FullName = "Sophia Müller", Email = "sophia.mueller@gmail.com", PhoneNumber = "-2345780", DateOfBirth = new DateTime(1992, 7, 18), Address = "22 Berliner Str, Berlin, Germany", CreatedDate = new DateTime(2025, 4, 5) });
                accountOps.Add(new Customer { FullName = "Ethan Brown", Email = "ethan.brown@yahoo.com", PhoneNumber = "-1374", DateOfBirth = new DateTime(1989, 2, 14), Address = "17 King St, Sydney, Australia", CreatedDate = new DateTime(2025, 5, 1) });

            }
            // Example usage
            Console.WriteLine("Displaying all customers:");
            accountOps.Display();

            Console.WriteLine("\nUpdating customer address...");
            accountOps.Update(2, "New Address, Madrid, Spain");

            Console.WriteLine("\nAfter update:");
            accountOps.Display();

            Console.WriteLine("\nDeleting customer with ID 5...");
            accountOps.Delete(5);

            Console.WriteLine("\nFinal list:");
            accountOps.Display();

            Console.ReadLine();
        }
    }
}
