using System.Transactions;

namespace Student4;

public abstract class CheckingAccount : Account
{
    private static double COST_PER_TRANSACTION = 0.05;
    private static double INTEREST_RATE = 0.005;
    private bool hasOverdraft;

    public CheckingAccount(decimal balance = 0, bool hasOverdraft = false)
        : base ("CK", balance)
    {
        this.hasOverdraft = hasOverdraft;
    }

    public new void Deposit(decimal amount, Person person)
    {
        base.Deposit(amount);
        OnTransactionOccur(new TransactionEventArgs(person.Name, amount, true););
    }

    public void Withdraw(decimal amount, Person person)
    {
        if (!IsUser(person))
        {
            OnTransactionOccur(new TransactionEventArgs(person.Name, amount, false));
            throw new AccountException("Person is not associated with this account.");
        }

        if (!IsLoggedIn)
        {
            OnTransactionOccur(new TransactionEventArgs(person.Name, amount, false));
            throw new AccountException("Person is not logged in.");
        }

        if (amount > Balance && !HasOverdraft)
        {
            OnTransactionOccur(new TransactionEventArgs(person.Name, amount, false));
            throw new AccountException("Amount is greater than the balance.");
        }
        
        OnTransactionOccur(new TransactionEventArgs(person.Name, amount, true));
        Deposit(-amount);
    }

    

    public override void PrepareMonthlyReport()
    {
        decimal ServiceChange = COST_PER_TRANSACTION * TransactionNumber;
        decimal Interest = (INTEREST_RATE * LowestBalance) / 12;

        decimal Balance+= (Interest - ServiceChange);

        transactions.Clear();
        
    }

    
}








