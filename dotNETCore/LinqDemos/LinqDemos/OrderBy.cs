using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqDemos
{
    public class User3
    {
        public string FirstName { get; set; }
        public string Lastname{ get; set; }
        public int Salary{ get; set; }
        public User3(string fname, string lname, int salary)
        {
            FirstName = fname;
            Lastname = lname;
            Salary = salary;
        }
    }
    public class OrderBy
    {
        public static void Run()
        {
            Console.WriteLine("OrderBy...");
            int[] vals = { 4, 5, 3, 2, 7, 0, 1, 6 };
            Console.WriteLine(string.Join(", ", vals));

            // SELECT Num FROM vals ORDER BY Num ASC
            var result = from e in vals
                         orderby e ascending
                         select e;

            Console.WriteLine(string.Join(", ", result));

            var result2 = from e in vals
                          orderby e descending
                          select e;

            Console.WriteLine(string.Join(", ", result2));

            var users = new List<User3>
            {
                new ("John", "Doe", 1230),
                new ("Lucy", "Novak", 670),
                new ("Ben", "Walter", 2050),
                new ("Robin", "Brown", 2300),
                new ("Amy", "Doe", 1250),
                new ("Joe", "Draker", 1190),
                new ("Janet", "Doe", 980),
                new ("Albert", "Novak", 1930),
            };

            Console.WriteLine("---------------------");
            Console.WriteLine("Sort ascending by last name and salary");

            // SELECT * FROM Orders ORDER BY Lastname, Salary.
            var sortedUsers = users.OrderBy(u => u.Lastname).ThenBy(u => u.Salary);

            foreach (var user in sortedUsers)
            {
                Console.WriteLine($"{user.FirstName}, {user.Lastname}, {user.Salary}");
            }

            Console.WriteLine("---------------------");
            Console.WriteLine("Sort descending by last name and salary");

            var sortedUsers2 = users.OrderByDescending(u => u.Lastname)
                .ThenByDescending(u => u.Salary);

            foreach (var user in sortedUsers2)
            {
                Console.WriteLine($"{user.FirstName}, {user.Lastname}, {user.Salary}");
            }

            Console.WriteLine();
        }
    }
}
