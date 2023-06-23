using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Entities
{
    public class FixedDepositAccount : Account
    {
        public int Tenure { get; set; }
        public decimal InterestRate { get; set; }
        public DateTime MaturesOn { get; set; }

        public FixedDepositAccount()
        {
            this.MinimumBalance = 500;
            this.AccountType = AccountTypes.FixedDeposit;
        }

        public override void Withdraw(decimal amount)
        {
            if (this.IsActive)
            {
                throw new Exception($"Cannot withdraw without closing the account first.");
            }
            Balance -= amount;
        }

        public override void Deposit(decimal amount)
        {
            throw new Exception($"Cannot deposit into a Fixed Deposit.");
        }

        public override string ToString()
        {
            var str = $"Customer Id: {this.Customer.Id}" +
                $" | Account Id: {this.Id}" +
                $" | Type: {this.GetAccountType()}" +
                $" | Created on: {this.CreatedOn.ToString("dd-MMM-yyyy")}" +
                $" | Balance: {this.Balance}" +
                $" | Tenure: {this.Tenure}" +
                $" | Matures On: {this.MaturesOn.ToString("dd-MMM-yyyy")}" +
                $" | Interest Rate: {this.InterestRate}";
            return str;
        }

    }
}
