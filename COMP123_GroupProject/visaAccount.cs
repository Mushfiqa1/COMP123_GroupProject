public class VisaAccount : Account
{
    public decimal CreditLimit { get; private set; }  // Credit limit for the Visa account
    public decimal InterestRate { get; private set; }  // Interest rate (annual)

    public VisaAccount(string accountId, decimal creditLimit, decimal interestRate)
        : base(accountId)
    {
        CreditLimit = creditLimit;
        InterestRate = interestRate;
    }

    // Overriding ProcessTransaction to handle credit-specific transactions
    public new void ProcessTransaction(string transactionType, decimal amount)
    {
        if (transactionType == "Withdraw" && Balance + amount > CreditLimit)
        {
            Console.WriteLine("Transaction declined: Credit limit exceeded.");
            return;  // Prevent exceeding credit limit
        }
        
        base.ProcessTransaction(transactionType, amount);
    }

    // Method to apply interest on outstanding balance
    public void ApplyInterest()
    {
        if (Balance > 0)
        {
            decimal interest = Balance * (InterestRate / 100);
            Balance += interest;  // Add interest to the balance
            Console.WriteLine($"Interest applied: {interest:C}. New balance: {Balance:C}");
        }
        else
        {
            Console.WriteLine("No interest applied. Balance is zero or negative.");
        }
    }

    // Method to make a payment toward the Visa account balance
    public void MakePayment(decimal paymentAmount)
    {
        if (paymentAmount <= 0)
        {
            Console.WriteLine("Invalid payment amount.");
            return;
        }

        Balance -= paymentAmount;
        if (Balance < 0) Balance = 0;  // Prevent negative balance

        Console.WriteLine($"Payment made: {paymentAmount:C}. New balance: {Balance:C}");
    }
}
