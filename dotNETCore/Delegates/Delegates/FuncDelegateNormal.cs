using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    public class FuncDelegateNormal
    {
        // Declaring the delegate
        public delegate int FuncDelegate(int s, int d, int f, int g);

        // Method
        public static int Multiply(int s, int d, int f, int g)
        {
            Console.WriteLine($"Multiplying {s} * {d} * {f} * {g}");
            return s * d * f * g;
        }

        static public void Go()
        {
            Console.WriteLine("\n\nNormal Delegate before showing 'Func' delegate...");
            // Creating object of my_delegate
            FuncDelegate obj = Multiply;
            Console.WriteLine($"Result is: {obj(12, 34, 35, 34)}");
        }
    }
}
