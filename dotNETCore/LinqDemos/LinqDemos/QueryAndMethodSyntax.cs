using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqDemos
{
    public class QueryAndMethodSyntax
    {
        public static void Run()
        {
            Console.WriteLine("Query and Method Syntax...");
            var words = new string[] { "falcon", "eagle", "sky", "tree", "water" };

            // Query syntax
            var res = from word in words
                      where word.Contains('a')
                      select word;

            foreach (var word in res)
            {
                Console.WriteLine(word);
            }

            Console.WriteLine("-----------");

            // Method syntax
            var res2 = words.Where(word => word.Contains('a'));

            foreach (var word in res2)
            {
                Console.WriteLine(word);
            }
            Console.WriteLine();
        }
    }
}
