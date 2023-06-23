using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Entities
{
    public static class AccountFactory
    {
        public static Account Get(AccountTypes accountType)
        {
            var factory = accountFactories[(int)accountType];
            return factory();
        }

        public static Dictionary<int, Func<Account>> accountFactories =
            new Dictionary<int, Func<Account>>
            {
                {0, () => new SavingsAccount() },
                {1, () => new CurrentAccount() },
                //{2, () => new FixedDepositAccount() },
            };
    }
}
