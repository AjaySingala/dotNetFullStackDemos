using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Entities
{
    public enum TransactionType
    {
        Create,
        Deposit,
        Withdraw,
        Close
    }
    public class Transaction
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        //public Customer Customer { get; set; }

        public int AccountId { get; set; }
        //public Account Account { get; set; }
        public DateTime TransactionDate { get; set; }
        public TransactionType TransactionType { get; set; }
        public decimal Amount { get; set; }
        public decimal Balance { get; set; }

        public override string ToString()
        {
            var str = $"Txn Id: {Id}" +
                $" | {CustomerId}" +
                $" | {AccountId}" +
                $" | {TransactionDate.ToString("dd-MMM-yyyy")}" +
                $" | {TransactionType}" +
                $" | {Amount}" +
                $" | {Balance}";

            return str;
        }
    }
}
