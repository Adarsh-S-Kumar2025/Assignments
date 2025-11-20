using System;
using System.Linq;
using BankingApp.Data;
using BankingApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BankingApp.Services
{
    public class AccountOperations
    {
        private readonly BankingAppDbContext _context;

        public AccountOperations()
        {
            _context = new BankingAppDbContext();
        }

        // Add a new customer (with address and one account)
        public void Add(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            Console.WriteLine("✅ Customer added successfully!");
        }

        // Display all customers with details
        public void Display()
        {
            var customers = _context.Customers
                .Include(c => c.Address)
                .Include(c => c.Accounts)
                .ToList();

            if (!customers.Any())
            {
                Console.WriteLine("⚠️ No customers found.");
                return;
            }

            foreach (var c in customers)
            {
                string address = c.Address != null
                    ? $"{c.Address.Street}, {c.Address.City}, {c.Address.State}, {c.Address.PostalCode}, {c.Address.Country}"
                    : "No address";

                string accounts = c.Accounts.Any()
                    ? string.Join(" | ", c.Accounts.Select(a => $"{a.AccountNumber} ({a.Balance:C})"))
                    : "No accounts";

                Console.WriteLine($"Customer Name: {c.FullName}; Address: {address}; Account: {accounts}");
            }
        }

        // Add or update address for customer
        public void AddAddress(int customerId, Address address)
        {
            var customer = _context.Customers
                .Include(c => c.Address)
                .FirstOrDefault(c => c.Id == customerId);

            if (customer == null)
            {
                Console.WriteLine("❌ Customer not found.");
                return;
            }

            if (customer.Address == null)
            {
                customer.Address = address;
            }
            else
            {
                // Update existing address
                customer.Address.Street = address.Street;
                customer.Address.City = address.City;
                customer.Address.State = address.State;
                customer.Address.PostalCode = address.PostalCode;
                customer.Address.Country = address.Country;
            }

            _context.SaveChanges();
            Console.WriteLine("✅ Address added/updated successfully!");
        }

        // Add an account for a customer
        public void AddAccount(int customerId, Account account)
        {
            var customer = _context.Customers.Include(c => c.Accounts).FirstOrDefault(c => c.Id == customerId);
            if (customer == null)
            {
                Console.WriteLine("❌ Customer not found.");
                return;
            }

            customer.Accounts.Add(account);
            _context.SaveChanges();
            Console.WriteLine("✅ Account added successfully!");
        }

        // Delete an account for a customer
        public void DeleteAccount(int customerId, int accountId)
        {
            var customer = _context.Customers
                .Include(c => c.Accounts)
                .FirstOrDefault(c => c.Id == customerId);

            if (customer == null)
            {
                Console.WriteLine("❌ Customer not found.");
                return;
            }

            var account = customer.Accounts.FirstOrDefault(a => a.Id == accountId);
            if (account == null)
            {
                Console.WriteLine("❌ Account not found for this customer.");
                return;
            }

            _context.Accounts.Remove(account);
            _context.SaveChanges();
            Console.WriteLine("✅ Account deleted successfully!");
        }
    }
}
