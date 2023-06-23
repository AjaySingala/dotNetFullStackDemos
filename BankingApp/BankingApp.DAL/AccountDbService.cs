using BankingApp.Entities;

namespace BankingApp.DAL
{
    public class AccountDbService
    {
        static List<Account> _accounts = new List<Account>();

        public Account Create(Account account)
        {
            // Generate random Account Number (id).
            var rnd = new Random();
            account.Id = rnd.Next(21000, 30000);

            // Set the id.
            account.CustomerId = account.Customer.Id;

            // Add account to list of accounts.
            _accounts.Add(account);

            return account;
        }

        public Account Get(int id)
        {
            var account = _accounts
                .Where(a => a.Id == id)
                .FirstOrDefault<Account>();
            return account;

        }

        public List<Account> GetByCustomerId(int id)
        {
            var accounts = _accounts
                .Where(a => a.Customer.Id == id)
                .ToList<Account>();
            return accounts;
        }

    }
}