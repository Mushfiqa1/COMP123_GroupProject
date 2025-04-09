using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account
{
   
    public abstract class Account
    {
        private static int LAST_NUMBER = 100_000;
        protected readonly List<Person> users = new List<Person>();
        public readonly List<Transaction> transactions = new List<Transaction>();
        public event TransactionEventHandler OnTranaction;

        public string Number { get; } //account number
        public decimal Balance { get; protected set; } //amount in this account and modified in the Deposit() and PrepareMonthlyReport()

        public decimal LowestBalance { get; protected set; }    //lowest balance that this amount ever drops to

        public Account(string type, decimal balance)
        {
            Number = $"{type}+{LAST_NUMBER++}";
            Balance = balance ;
            LowestBalance = balance ;
        }
        protected void Deposit(decimal amount, Person person)
        {
            Balance += amount;
            if(Balance < LowestBalance)
            {
                LowestBalance = Balance;
            }
            Transaction transaction = new Transaction(Number, amount, person);
                transactions.Add(transaction);
            
        }
        public void AddUser(Person user)
        {
           users.Add(user);
        }
        public bool IsUser(Person user)
        {
            foreach(var accountUser in users)
            {
                if(accountUser.Name == user.Name)
                {
                    return true;
                }
            }
            return false; 
        }
        public abstract void PrepareMonthlyStatement()
        {

        }
        public virtual void OnTransactionOccur(object sender, TransactionEventArgs e)
        {
            OnTransaction?.Invoke(sender, e);
        }
        public override string ToString()
        {
            string result = $"Account Number:{Number}\nUsers:";
            foreach(var user in users)
            {
                result += user.Name + ",";
            }
            result = result + "\n";
            result += $"{Balance:C}\n Transactions:\n";
            foreach(var transaction  in transactions)
            {
                result += transaction.ToString()+"\n";
            }
            return result ;
        }
    }
}
