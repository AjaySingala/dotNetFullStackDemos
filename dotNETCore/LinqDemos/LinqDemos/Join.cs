using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqDemos
{
    public class Join
    {
        public static void Run()
        {
            Console.WriteLine("Join...");
            string[] basketA = { "coin", "book", "fork", "cord", "needle" };
            string[] basketB = { "watches", "coin", "pen", "book", "pencil" };

            // SELECT item FROM basketA INNER JOIN basketB ON basketA.item = basketB.item.
            var res = from item1 in basketA
                      join item2 in basketB
                      on item1 equals item2
                      select item1;

            foreach (var item in res)
            {
                Console.WriteLine(item);
            }


            Console.WriteLine();
        }
    }
}
