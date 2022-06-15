using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    public class MyDelegate
    {
        public delegate void Del(string message);
        public delegate void AddNumbers(int x, int y);
        public delegate void SubtractNumbers(int x, int y);
    }
}
