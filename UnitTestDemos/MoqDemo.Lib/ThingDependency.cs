using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoqDemo.Lib
{
    public class ThingDependency : IThingDependency
    {
        public string JoinUpper(string a, string b)
        {
            throw new NotImplementedException();
        }

        public int Meaning => throw new NotImplementedException();

        //public bool Charge(string name, int number, int cvv)
        public bool Charge(int amount, Card card)
        {
            throw new NotImplementedException();
        }
    }
}
