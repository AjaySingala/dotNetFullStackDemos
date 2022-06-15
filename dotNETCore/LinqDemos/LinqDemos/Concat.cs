using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqDemos
{
    public class User2
    {
        public string FirstName { get; set; }
        public string Lastname{ get; set; }
        public string Occupation{ get; set; }
        public User2(string fname, string lname, string occupation)
        {
            FirstName = fname;
            Lastname = lname;
            Occupation = occupation;
        }
    }
    public class Concat
    {
        public static void Run()
        {
            Console.WriteLine("Concat...");
            User2[] users1 =
            {
                new User2("John", "Doe", "gardener"),
                new User2("Jane", "Doe", "teacher"),
                new User2("Roger", "Roe", "driver")
            };

            User2[] users2 =
            {
                new User2("Peter", "Smith", "teacher"),
                new User2("Lucia", "Black", "accountant"),
                new User2("Michael", "Novak", "programmer")
            };

            var allUsers = users1.Concat(users2);

            foreach (var user in allUsers)
            {
                Console.WriteLine($"{user.FirstName}, {user.Lastname}, {user.Occupation}");
            }

            Console.WriteLine();
        }
    }
}
