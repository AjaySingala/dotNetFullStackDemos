using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    public class FuncDelegate
    {
        // No delegate is defined here!!!

        // Method
        public static int Multiply(int s, int d, int f, int g)
        {
            Console.WriteLine($"Multiplying {s} * {d} * {f} * {g}");
            return s * d * f * g;
        }

        public static int Add(int num)
        {
            Console.WriteLine($"Adding {num} to itself...");
            return num + num;
        }
        static public void Go()
        {
            Console.WriteLine("\n\nNow showing the 'Func' delegate...");
            // Using Func delegate.
            // Here, Func delegate contains the four parameters of int type and
            // one result parameter of int type.
            Func<int, int, int, int, int> val = Multiply;
            Console.WriteLine($"Result is: {val(10, 100, 1000, 1)}");

            // Using Func delegate.
            // Here, Func delegate contains the one parameters of int type and
            // one result parameter of int type.
            Func<int, int> addFunc = Add;
            Console.WriteLine(addFunc(10));

            // Use a Func delegate with an anonymous method.
            Func<int, int, int, int> anonFunc = delegate (int x, int y, int z)
            {
                return x + y + z;
            };
            Console.WriteLine($"Func Delegate with an Anonymous method: {anonFunc(10, 20, 30)}");

            // Use a Func delegate with a lambda expression.
            Func<int, int, int, int> lambdaFunc = (int x, int y, int z) => x + y + z;
            Console.WriteLine($"Func Delegate with a Lambda Expression: {lambdaFunc(5, 10, 25)}");
        }
    }
}
