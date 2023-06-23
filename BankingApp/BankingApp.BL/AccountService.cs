using BankingApp.DAL;
using BankingApp.Entities;

namespace BankingApp.BL
{
    public class AccountService
    {
        public Account Create(Account account)
        {
            AccountDbService svc = new AccountDbService();
            svc.Create(account);

            return account;
        }

        public Account Get(int id) 
        {
            AccountDbService svc = new AccountDbService();
            var account = svc.Get(id);
            return account;
        }
        public List<Account> GetByCustomerId(int id)
        {
            AccountDbService svc = new AccountDbService();
            var accounts = svc.GetByCustomerId(id);
            return accounts;
        }
    }
}