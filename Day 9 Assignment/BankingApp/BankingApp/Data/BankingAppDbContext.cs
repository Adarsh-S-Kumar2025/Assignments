using BankingApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BankingApp.Data
{
    public class BankingAppDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Adjust as needed for your SQL Server setup
            optionsBuilder.UseSqlServer("Server=localhost;Database=BankingAppDB;User Id=sa;Password=12345678Aa;TrustServerCertificate=True;");
        }
    }
}
