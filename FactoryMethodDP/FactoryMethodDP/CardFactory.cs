using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodDP
{
    /// <summary>  
    /// The 'Creator' Abstract Class  
    /// </summary>  
    // This could be an interface.
    abstract class CardFactory
    {
        public abstract CreditCard GetCreditCard();
    }
}
