using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAnnotations
{
    public class CreditCard
    {
        public string CardType { get; set; }
        public string NameOnCard { get; set; }
        [CreditCard()]
        public string CardNumber { get; set; }
        public string SecurityCode { get; set; }
        public int ExpMonth { get; set; }
        public int ExpYear { get; set; }
        public string BillingPostalCode { get; set; }
    }
}
