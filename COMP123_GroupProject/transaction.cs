public class Transaction
{
    public string AccountNumber { get; set; }
    public decimal Amount { get; set; }
    public string User { get; set; }
    public DateTime Date { get; set; }

    public Transaction(string accountNumber, decimal amount, string user, DateTime date)
    {
        AccountNumber = accountNumber;
        Amount = amount;
        User = user;
        Date = date;
    }
}

