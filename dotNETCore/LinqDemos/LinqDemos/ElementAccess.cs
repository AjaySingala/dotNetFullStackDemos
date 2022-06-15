using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqDemos
{
    public class ElementAccess
    {
        public static void Run()
        {
            Console.WriteLine("Element Access...");
            string[] words = { "falcon", "oak", "sky", "cloud", "tree", "tea", "water" };

            Console.WriteLine(string.Join(", ", words));
            Console.WriteLine($"At #2: {words.ElementAt(2)}");
            Console.WriteLine($"First: {words.First()}");
            Console.WriteLine($"Last :{words.Last()}");

            Console.WriteLine($"First with length == 3: {words.First(word => word.Length == 3)}");
            Console.WriteLine($"Last with length == 3: {words.Last(word => word.Length == 3)}");

            // Prepend adds a value to the beginning of the sequence.
            // Append appends a value to the end of the sequence.
            int[] vals = { 1, 2, 3 };

            vals.Prepend(0);
            vals.Append(4);

            Console.WriteLine(string.Join(", ", vals));

            var vals2 = vals.Prepend(0);
            var vals3 = vals2.Append(4);

            Console.WriteLine(string.Join(", ", vals3));

            Console.WriteLine();
        }
    }
}
