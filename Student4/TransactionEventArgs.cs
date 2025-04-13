namespace Student4;

public class TransactionEventArgs : LoginEventArgs
{
    public decimal Amount { get; }

    public TransactionEventArgs(string name, decimal amount, bool success, LoginEventType eventType)
        : base (name, success, eventType)
    {
        Amount = amount;
    }
    
}
