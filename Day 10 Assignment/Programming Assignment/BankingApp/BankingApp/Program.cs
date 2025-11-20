using System;
using BankingApp.Models;
using BankingApp.Services;

class Program
{
    static void Main()
    {
        var service = new AccountOperations();

        // Create a new customer with address and account
        var newCustomer = new Customer
        {
            FullName = "Adarsh Kumar",
            Email = "adarsh@example.com",
            PhoneNumber = "9999999999",
            DateOfBirth = new DateTime(1995, 5, 1),
            Address = new Address
            {
                Street = "123 MG Road",
                City = "Bangalore",
                State = "Karnataka",
                PostalCode = "560001",
                Country = "India"
            },
            Accounts = new()
            {
                new Account { AccountNumber = "ACC001", Balance = 10000 }
            }
        };

        service.Add(newCustomer);

        // Display all customers
        service.Display();

        // Add or update address
        service.AddAddress(newCustomer.Id, new Address
        {
            Street = "456 Residency Road",
            City = "Bangalore",
            State = "Karnataka",
            PostalCode = "560002",
            Country = "India"
        });

        // Add a new account
        service.AddAccount(newCustomer.Id, new Account
        {
            AccountNumber = "ACC002",
            Balance = 5000
        });

        // Delete account
        service.DeleteAccount(newCustomer.Id, 1);

        // Display again
        service.Display();
    }
}
