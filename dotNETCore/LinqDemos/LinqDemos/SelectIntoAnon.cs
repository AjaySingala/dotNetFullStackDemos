using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqDemos
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string DateOfBirth { get; set; }
        public User(int id, string name, string city, string dob)
        {
            this.Id = id;
            this.Name = name;
            this.City = city;
            this.DateOfBirth = dob;
        }
    }

    public class SelectIntoAnon
    {
        public static void Run()
        {
            Console.WriteLine("Select into an Anonymous object...");
            User[] users =
            {
              new (1, "John", "London", "2001-04-01"),
              new (2, "Lenny", "New York", "1997-12-11"),
              new (3, "Andrew", "Boston", "1987-02-22"),
              new (4, "Peter", "Prague", "1936-03-24"),
              new (5, "Anna", "Bratislava", "1973-11-18"),
              new (6, "Albert", "Bratislava", "1940-12-11"),
              new (7, "Adam", "Trnava", "1983-12-01"),
              new (8, "Robert", "Bratislava", "1935-05-15"),
              new (9, "Robert", "Prague", "1998-03-14"),
            };

            // Select into an anon object.
            var res = from user in users
                      where user.City == "Bratislava"
                      select new { user.Name, user.City };

            Console.WriteLine(string.Join(", ", res));

            Console.WriteLine();
        }
    }
}
