using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDemo
{
    public class EventDemo2
    {
        public delegate void MyEventHandler(string a);

        public event MyEventHandler xyz;

        public void Action(string a)
        {
            if (xyz != null)
            {
                xyz(a);
                Console.WriteLine(a);
            }
            else
            {
                Console.WriteLine("Not Registered");
            }
        }
    }
}
