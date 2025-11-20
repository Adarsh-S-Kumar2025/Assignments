using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BankingApp.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string FullName { get; set; }

        [Required, MaxLength(256)]
        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime DateOfBirth { get; set; }

        public Address Address { get; set; }   // One-to-one
        public List<Account> Accounts { get; set; } = new List<Account>(); // One-to-many
    }
}
