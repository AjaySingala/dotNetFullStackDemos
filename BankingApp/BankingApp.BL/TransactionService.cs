using BankingApp.DAL;
using BankingApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BankingApp.BL
{
    public class TransactionService
    {
        public void Create(Transaction txn)
        {
            var svc = new TransactionDbService();
            svc.Create(txn);
        }

        public List<Transaction> Get()
        {
            var svc = new TransactionDbService();
            var txns = svc.Get();

            return txns;
        }

        public Transaction Get(int txnId)
        {
            var svc = new TransactionDbService();
            var txn = svc.Get(txnId);

            return txn;
        }
    }
}
