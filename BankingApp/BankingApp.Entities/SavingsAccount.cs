using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Entities
{
    public class SavingsAccount : Account
    {
        public SavingsAccount()
        {
            this.MinimumBalance = 500;
            this.AccountType = AccountTypes.Savings;
        }

        public override void Withdraw(decimal amount)
        {
            if(amount > Balance)
            {
                throw new Exception($"Insufficient balance...");
            }
            if(Balance - amount < MinimumBalance)
            {
                throw new Exception($"Withdraw failed! Balance cannot be less than {MinimumBalance}");
            }
            Balance -= amount;
        }

    }
}
