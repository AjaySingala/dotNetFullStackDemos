using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqDemos
{
    public class Select
    {
        public static void Run()
        {
            Console.WriteLine("Select...");
            int[] vals = { 2, 4, 6, 8 };

            var powered = vals.Select(e => Math.Pow(e, 2));
            Console.WriteLine(string.Join(", ", powered));

            string[] words = { "sky", "earth", "oak", "falcon" };
            var wordLens = words.Select(e => e.Length);
            Console.WriteLine(string.Join(", ", wordLens));

            Console.WriteLine();
        }
    }
}
