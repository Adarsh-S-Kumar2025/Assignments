using System;
using System.Linq;
using BankingApp.Data;
using BankingApp.Models;

namespace BankingApp.Operations
{
    public class AccountOperations
    {
        private readonly BankingAppDbContext _context;

        public AccountOperations()
        {
            _context = new BankingAppDbContext();
        }

        // Add new customer
        public void Add(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            Console.WriteLine($"Customer '{customer.FullName}' added successfully.");
        }

        // Update address
        public void Update(int customerId, string newAddress)
        {
            var customer = _context.Customers.Find(customerId);
            if (customer == null)
            {
                Console.WriteLine("Error: Customer not found.");
                return;
            }

            customer.Address = newAddress;
            _context.SaveChanges();
            Console.WriteLine($"Address updated for {customer.FullName}.");
        }

        // Delete customer
        public void Delete(int customerId)
        {
            var customer = _context.Customers.Find(customerId);
            if (customer == null)
            {
                Console.WriteLine("Error: Customer not found.");
                return;
            }

            _context.Customers.Remove(customer);
            _context.SaveChanges();
            Console.WriteLine($"Customer '{customer.FullName}' deleted successfully.");
        }

        // Display all customers
        public void Display()
        {
            var customers = _context.Customers.ToList();

            if (customers.Count == 0)
            {
                Console.WriteLine("No customers found.");
                return;
            }

            Console.WriteLine("\n---- Customer List ----");
            foreach (var c in customers)
            {
                Console.WriteLine($"ID: {c.Id}");
                Console.WriteLine($"Name: {c.FullName}");
                Console.WriteLine($"Email: {c.Email}");
                Console.WriteLine($"Phone: {c.PhoneNumber}");
                Console.WriteLine($"DOB: {c.DateOfBirth:yyyy-MM-dd}");
                Console.WriteLine($"Address: {c.Address}");
                Console.WriteLine($"Created: {c.CreatedDate:yyyy-MM-dd}");
                Console.WriteLine("------------------------------");
            }
        }
    }
}
