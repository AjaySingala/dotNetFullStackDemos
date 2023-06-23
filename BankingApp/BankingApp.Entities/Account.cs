using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Entities
{
    public enum AccountTypes
    {
        Savings= 0,
        Current = 1,
        FixedDeposit = 2
    }

    public abstract class Account
    {
        protected decimal MinimumBalance { get; set; }
        protected AccountTypes AccountType { get; set; }

        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsActive { get; set; }
        public decimal Balance { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public virtual void Close()
        {
            this.IsActive = false;
            Withdraw(this.Balance);
        }

        public virtual void Deposit(decimal amount)
        {
            this.Balance += amount;
        }

        public virtual void Withdraw(decimal amount)
        {
            this.Balance -= amount;
        }

        public AccountTypes GetAccountType()
        {
            return this.AccountType;
        }

        public override string ToString()
        {
            var str = $"Customer Id: {this.Customer.Id}" +
                $" | Account Id: {this.Id}" +
                $" | Type: {this.GetAccountType()}" +
                $" | Created on: {this.CreatedOn.ToString("dd-MMM-yyyy")}" +
                $" | Balance: {this.Balance}";
            return str;
        }
    }
}
