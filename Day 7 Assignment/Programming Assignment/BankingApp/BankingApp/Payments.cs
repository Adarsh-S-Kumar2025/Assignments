using System;

namespace BankingApp
{
    // IPaymentService interface
    public interface IPaymentService
    {
        void MakePayment(double amount);
    }

    // Credit Card Payment
    public class CreditCardPayment : IPaymentService
    {
        public void MakePayment(double amount)
            => Console.WriteLine($"Paid {amount:C} using Credit Card.");
    }

    // UPI Payment
    public class UPIPayment : IPaymentService
    {
        public void MakePayment(double amount)
            => Console.WriteLine($"Paid {amount:C} using UPI.");
    }

    // Net Banking Payment
    public class NetBankingPayment : IPaymentService
    {
        public void MakePayment(double amount)
            => Console.WriteLine($"Paid {amount:C} using Net Banking.");
    }
}
