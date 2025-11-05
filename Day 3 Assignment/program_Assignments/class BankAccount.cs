class BankAccount
{
    public int AccountNumber;
    public string AccountHolder;
    public double Balance;

    public BankAccount() : this(0, "Unknown", 0) { }

    public BankAccount(int accNo, string holder, double balance)
    {
        AccountNumber = accNo;
        AccountHolder = holder;
        Balance = balance;
    }

    public void Deposit(double amount)
    {
        Balance += amount;
        Console.WriteLine($"Deposited: {amount}, New Balance: {Balance}");
    }

    public void DisplayBalance()
    {
        Console.WriteLine($"Account: {AccountNumber}, Holder: {AccountHolder}, Balance: {Balance}");
    }
}
