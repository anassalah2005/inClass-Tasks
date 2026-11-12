List<Ipayment> payments = new List<Ipayment>();
payments.Add(new creditcardpayment());
payments.Add(new paypalpayment());
payments.Add(new Banktransferpayment());
BankAccount account = new BankAccount("123456789");
account.deposit(1000, payments[0]);
Console.WriteLine($"Current balance: {account.balance}");
account.withdraw(500, payments[1]);
Console.WriteLine($"Current balance: {account.balance}");

foreach (Ipayment payment in payments)
{
    Console.WriteLine($"Payment type: {payment.getpaymenttype()}");
    payment.processPayment(100);
}
interface Ipayment
{
    bool processPayment(decimal amount);
    string getpaymenttype();

}
// payment class 
class creditcardpayment : Ipayment
{
    public bool processPayment(decimal amount)
    {
        Console.WriteLine($"Processing credit card payment of {amount}");
        return true;
    }
    public string getpaymenttype()
    {
        return "Credit Card";
    }
}
class paypalpayment : Ipayment
{
    public bool processPayment(decimal amount)
    {
        Console.WriteLine($"Processing PayPal payment of {amount}");
        return true;
    }
    public string getpaymenttype()
    {
        return "PayPal";
    }
}
class Banktransferpayment : Ipayment
{
    public bool processPayment(decimal amount)
    {
        Console.WriteLine($"Processing bank transfer payment of {amount}");
        return true;
    }
    public string getpaymenttype()
    {
        return "Bank Transfer";
    }
}
class BankAccount
{
    private string account;
    private decimal Balance;
    public BankAccount(string accountNumber)
    {
        account = accountNumber;
    }

    public decimal balance
    {
        get { return Balance; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Balance cannot be negative.");
            }
            Balance = value;
        }


    }
    public void withdraw(decimal amount, Ipayment paymentMethod)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Withdrawal amount must be greater than zero.");
        }
        Console.WriteLine($"Withdrawing {amount} from bank account {account}");
    }

    public void deposit(decimal amount, Ipayment paymentMethod)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Deposit amount must be greater than zero.");
        }
        Console.WriteLine($"Depositing {amount} to bank account {account}");
        if (paymentMethod.processPayment(amount))
        {
            Balance += amount;
            Console.WriteLine($"Deposit successful. New balance: {Balance}");
        }
        else
        {
            Console.WriteLine("Deposit failed.");
        }
    }



}
