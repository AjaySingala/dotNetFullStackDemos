using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqDemos
{
    public class Aggregates
    {
        public static void Run()
        {
            Console.WriteLine("Aggregates...");
            var vals = new List<int> { 6, 2, -3, 4, -5, 9, 7, 8 };
            Console.WriteLine(string.Join(", ", vals));

            var n1 = vals.Count();
            Console.WriteLine($"There are {n1} elements");

            var n2 = vals.Count(e => e % 2 == 0);
            Console.WriteLine($"There are {n2} even elements");

            var sum = vals.Sum();
            Console.WriteLine($"The sum of all values is: {sum}");

            var s2 = vals.Sum(e => e > 0 ? e : 0);
            Console.WriteLine($"The sum of all positive values is: {s2}");

            var avg = vals.Average();
            Console.WriteLine($"The average of values is: {avg}");

            var max = vals.Max();
            Console.WriteLine($"The maximum value is: {max}");

            var min = vals.Min();
            Console.WriteLine($"The minimum value is: {min}");

            Console.WriteLine("\nUsing Query expressions...");
            var vals2 = new List<int> { 1, -2, 3, -4, 5, 6, 7, -8 };
            Console.WriteLine(string.Join(", ", vals2));

            var s = (from x in vals2 where x > 0 select x).Sum();

            Console.WriteLine($"The sum of positive values is: {s}");

            var words = new List<string> { "falcon", "eagle", "hawk", "owl" };
            Console.WriteLine(string.Join(", ", words)); 
            
            int len = (from x in words select x.Length).Sum();

            Console.WriteLine($"There are {len} letters in the list");

            Console.WriteLine();
        }
    }
}
