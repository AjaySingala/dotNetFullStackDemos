using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Entities
{
    public class CurrentAccount : Account
    {
        public CurrentAccount()
        {
            this.MinimumBalance = 0;
            this.AccountType = AccountTypes.Current;
        }

        public override void Withdraw(decimal amount)
        {
            if(Balance - amount < MinimumBalance)
            {
                Console.WriteLine($"WARNING! Balance will be less than {MinimumBalance} after this withdrawal.");
            }
            Balance -= amount;
        }
    }
}
