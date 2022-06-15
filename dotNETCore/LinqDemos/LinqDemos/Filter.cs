using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqDemos
{
    public class Car
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public Car(string name, int price)
        {
            Name = name;
            Price = price;
        }
    }

    public class Filter
    {
        public static void Run()
        {
            Console.WriteLine("Filter...");
            var words = new List<string> { "sky", "rock", "forest", "new",
                "falcon", "jewelry", "eagle", "blue", "gray" };

            var query = from word in words
                        where word.Length == 4
                        select word;

            foreach (var word in query)
            {
                Console.WriteLine(word);
            }

            Console.WriteLine("\nUse the || operator to combine conditions...");
            words = new List<string> { "sky", "rock", "forest", "new",
                "falcon", "jewelry", "small", "eagle", "blue", "gray" };

            var res = from word in words
                      where word.StartsWith('f') || word.StartsWith('s')
                      select word;

            foreach (var word in res)
            {
                Console.WriteLine(word);
            }

            Console.WriteLine("\nApply two conditions with &&...");
            var cars = new List<Car>
            {
                new ("Audi", 52642),
                new ("Mercedes", 57127),
                new ("Skoda", 9000),
                new ("Volvo", 29000),
                new ("Bentley", 350000),
                new ("Citroen", 21000),
                new ("Hummer", 41400),
                new ("Volkswagen", 21600),
            };

            var res2 = from car in cars
                      where car.Price > 30000 && car.Price < 100000
                      select new { car.Name, car.Price };

            foreach (var car in res2)
            {
                Console.WriteLine($"{car.Name} {car.Price}");
            }

            Console.WriteLine();
        }
    }
}
