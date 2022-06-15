using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    public class MyMethodClass
    {
        public void Method1(string msg)
        {
            Console.WriteLine($"Method1: {msg}");
        }

        public void Method2(string msg)
        {
            Console.WriteLine($"Method2: {msg}");
        }
    }
}
