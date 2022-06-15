using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqDemos
{
    public class SelectMany
    {
        public static void Run()
        {
            Console.WriteLine("Select Many...");
            int[][] vals = {
                new[] {1, 2, 3},
                new[] {4},
                new[] {5, 6, 6, 2, 7, 8},
            };

            var res = vals.SelectMany(array => array).OrderBy(x => x);

            Console.WriteLine(string.Join(", ", res));

            var vals2 = new List<List<int>> {
                new List<int> {1, 2, 3, 3},
                new List<int> {4},
                new List<int> {5, 6, 6, 7, 7}
            };

            var res2 = vals2.SelectMany(list => list)
                          .Distinct()
                          .OrderByDescending(e => e);

            Console.WriteLine(string.Join(", ", res2));

            Console.WriteLine();
        }
    }
}
