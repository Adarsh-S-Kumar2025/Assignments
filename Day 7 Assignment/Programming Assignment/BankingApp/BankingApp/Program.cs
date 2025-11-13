using System;

namespace BankingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Accounts demo
            IAccount savings = new SavingsAccount();
            savings.Deposit(5000);
            savings.Withdraw(1500);
            Console.WriteLine($"Savings Account Balance: {savings.GetBalance():C}");

            IAccount current = new CurrentAccount();
            current.Deposit(2000);
            current.Withdraw(2500);
            Console.WriteLine($"Current Account Balance: {current.GetBalance():C}");

            // Payments demo
            IPaymentService creditCard = new CreditCardPayment();
            PaymentProcessor processor1 = new PaymentProcessor(creditCard);
            processor1.ProcessPayment(1000);

            IPaymentService upi = new UPIPayment();
            PaymentProcessor processor2 = new PaymentProcessor(upi);
            processor2.ProcessPayment(500);

            IPaymentService netBanking = new NetBankingPayment();
            PaymentProcessor processor3 = new PaymentProcessor(netBanking);
            processor3.ProcessPayment(2000);
        }
    }
}
