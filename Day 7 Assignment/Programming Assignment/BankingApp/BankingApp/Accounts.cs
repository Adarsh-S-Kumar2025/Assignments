using System;

namespace BankingApp
{
    // IAccount interface
    public interface IAccount
    {
        void Deposit(double amount);
        void Withdraw(double amount);
        double GetBalance();
    }

    // Savings Account
    public class SavingsAccount : IAccount
    {
        private double _balance;
        public void Deposit(double amount) => _balance += amount;
        public void Withdraw(double amount)
        {
            if (amount > _balance) throw new InvalidOperationException("Insufficient funds.");
            _balance -= amount;
        }
        public double GetBalance() => _balance;
    }

    // Current Account
    public class CurrentAccount : IAccount
    {
        private double _balance;
        private double _overdraftLimit = 1000;
        public void Deposit(double amount) => _balance += amount;
        public void Withdraw(double amount)
        {
            if (amount > _balance + _overdraftLimit)
                throw new InvalidOperationException("Exceeds overdraft limit.");
            _balance -= amount;
        }
        public double GetBalance() => _balance;
    }
}
