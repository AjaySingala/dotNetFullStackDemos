using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqDemos
{
    public class Car2
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public int Price { get; set; }
        public Car2(string name, string color, int price)
        {
            Name = name;
            Color = color;
            Price = price;
        }
    }

    public class Revenue
    {
        public int Id { get; set; }
        public string Quarter { get; set; }
        public int Amount { get; set; }
        public Revenue(int id, string quarter, int amount)
        {
            Id = id;
            Quarter = quarter;
            Amount = amount;
        }

    }

    public class GroupBy
    {
        public static void Run()
        {
            Console.WriteLine("GroupBy...");
            var cars = new List<Car2>
            {
                new ("Audi", "red", 52642),
                new ("Mercedes", "blue", 57127),
                new ("Skoda", "black", 9000),
                new ("Volvo", "red", 29000),
                new ("Bentley", "yellow", 350000),
                new ("Citroen", "white", 21000),
                new ("Hummer", "black", 41400),
                new ("Volkswagen", "white", 21600),
            };

            foreach (var car in cars)
            {
                // +ve: Right aligned.
                // -ve: Left aligned.
                Console.WriteLine($"{car.Name,-10}\t{car.Color}\t${car.Price}");
            }
            // SELECT * FROM Cars GROUP BY Color.
            var groups = from car in cars
                         group car by car.Color;

            foreach (var group in groups)
            {
                Console.WriteLine($"{group.Key}:");

                foreach (var car in group)
                {
                    Console.WriteLine($"\t{car.Name} {car.Price}");
                }
            }

            // Revenues: Grouping and Aggregation.
            Console.WriteLine("\nRevenues: Grouping and Aggregation...");
            Revenue[] revenues =
            {
                new (1, "Q1", 2340),
                new (2, "Q1", 1200),
                new (3, "Q1", 980),
                new (4, "Q2", 340),
                new (5, "Q2", 780),
                new (6, "Q3", 2010),
                new (7, "Q3", 3370),
                new (8, "Q4", 540),
            };
            foreach (var rev in revenues)
            {
                Console.WriteLine($"{rev.Id}\t{rev.Quarter}\t{rev.Amount}");
            }
            // SELECT Quarter, SUM(Amount) as 'Total' FROM revenues GROUP BY Quarter.
            var res = from revenue in revenues
                      group revenue by revenue.Quarter
                      into g
                      select new { Quarter = g.Key, Total = g.Sum(e => e.Amount) };

            foreach (var line in res)
            {
                Console.WriteLine(line);
            }

            Console.WriteLine();
        }
    }
}
