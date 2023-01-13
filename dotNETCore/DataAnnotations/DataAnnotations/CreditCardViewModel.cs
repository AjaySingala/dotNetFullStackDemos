using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAnnotations
{
    public class CreditCardViewModel
    {
        public CreditCardViewModel()
        {
            Entity = new();
        }
        public CreditCard Entity { get; set; }
        public List<ValidationMessage> Validate()
        {
            // Use Helper Class
            return ValidationHelper.Validate(Entity);
        }
    }
}
