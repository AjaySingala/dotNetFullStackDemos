using BankingApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.DAL
{
    public class TransactionDbService
    {
        static List<Transaction> _txns = new List<Transaction>();

        public void Create(Transaction txn)
        {
            // Generate random Account Number (id).
            var rnd = new Random();
            txn.Id = rnd.Next(31000, 40000);

            _txns.Add(txn);
        }

        public List<Transaction> Get()
        {
            var txns = _txns.ToList();
            return txns;
        }

        public Transaction Get(int txnId)
        {
            var txn = _txns
                .Where(t => t.Id == txnId)
                .FirstOrDefault<Transaction>();

            return txn;
        }
    }
}
