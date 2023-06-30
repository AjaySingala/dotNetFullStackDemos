namespace RecordTypeDemo
{
    internal class Program
    {
        public record Person(string FirstName, string LastName);
        public record Person2
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string City { get; init; }
        }

        static void Main(string[] args)
        {
            //PersonDemo();
            //ImmutabilityDemo();
            //ValueEqualityDemo();
            //NonDestructiveMutationDemo();
            //InheritanceDemo();
            EqualityInInheritanceDemo();
        }

        static void PersonDemo()
        {
            Console.WriteLine();
            Console.WriteLine("PersonDemo()...");

            Person person = new("Nancy", "Davolio");
            Console.WriteLine(person);
            Console.WriteLine($"{person.FirstName} {person.LastName}");

            ////person.FirstName = "John";    // ERROR!

            //Person2 person2 = new Person2 { City = "NYC" };
            //person2.FirstName = "Nancy";
            //person2.LastName = "Davolio";
            ////person2.City = "Dallas";      // ERROR!
            //Console.WriteLine(person);
            //Console.WriteLine($"{person.FirstName} {person.LastName}");
            //person2.FirstName = "John";
            //Console.WriteLine(person2);
        }

        public record Person3(string FirstName, string LastName, string[] PhoneNumbers);
        static void ImmutabilityDemo()
        {
            Console.WriteLine();
            Console.WriteLine("ImmutabilityDemo()...");

            Person3 person = new("Nancy", "Davolio", new string[1] { "555-1234" });
            Console.WriteLine(person.PhoneNumbers[0]); // output: 555-1234

            person.PhoneNumbers[0] = "555-6789";
            Console.WriteLine(person.PhoneNumbers[0]); // output: 555-6789
        }

        public record Person4(string FirstName, string LastName, string[] PhoneNumbers);

        public static void ValueEqualityDemo()
        {
            Console.WriteLine();
            Console.WriteLine("ValueEqualityDemo()...");


            var phoneNumbers = new string[2];
            Person4 person1 = new("Nancy", "Davolio", phoneNumbers);
            Person4 person2 = new("Nancy", "Davolio", phoneNumbers);
            Console.WriteLine(person1 == person2); // output: True

            person1.PhoneNumbers[0] = "555-1234";
            Console.WriteLine(person1 == person2); // output: True

            Console.WriteLine(ReferenceEquals(person1, person2)); // output: False
        }

        public record Person5(string FirstName, string LastName)
        {
            public string[] PhoneNumbers { get; init; }
        }

        public static void NonDestructiveMutationDemo()
        {
            Person5 person1 = new("Nancy", "Davolio") { PhoneNumbers = new string[1] };
            Console.WriteLine($"Person 1: {person1}");
            // output: Person { FirstName = Nancy, LastName = Davolio, PhoneNumbers = System.String[] }

            Person5 person2 = person1 with { FirstName = "John" };
            Console.WriteLine($"Person 2: {person2}");
            // output: Person { FirstName = John, LastName = Davolio, PhoneNumbers = System.String[] }
            Console.WriteLine($"person1 == person2? {person1 == person2}"); // output: False

            person2 = person1 with { PhoneNumbers = new string[2] };
            Console.WriteLine($"Person 2 after PhoneNumbers: {person2}");
            // output: Person { FirstName = Nancy, LastName = Davolio, PhoneNumbers = System.String[] }
            Console.WriteLine($"Person 1 PhoneNumbers Count: {person1.PhoneNumbers.Count()}");
            Console.WriteLine($"Person 2 PhoneNumbers Count: {person2.PhoneNumbers.Count()}");

            person2.PhoneNumbers[0] = "555-7890";
            Console.WriteLine($"Person 1 PhoneNumbers: {person1.PhoneNumbers[0]}");
            Console.WriteLine($"Person 2 PhoneNumbers: {person2.PhoneNumbers[0]}");

            Console.WriteLine($"person1 == person2? {person1 == person2}"); // output: False

            person2 = person1 with { };
            Console.WriteLine($"Person 1 without 'with': {person1}");
            Console.WriteLine($"Person 2 without 'with': {person2}");
            Console.WriteLine($"person1 == person2? {person1 == person2}"); // output: True
        }

        public abstract record Person6(string FirstName, string LastName);
        public record Teacher(string FirstName, string LastName, int Grade)
            : Person6(FirstName, LastName);
        public static void InheritanceDemo()
        {
            Person6 teacher = new Teacher("Nancy", "Davolio", 3);
            Console.WriteLine(teacher);
            // output: Teacher { FirstName = Nancy, LastName = Davolio, Grade = 3 }
        }

        public abstract record Person7(string FirstName, string LastName);
        public record Teacher2(string FirstName, string LastName, int Grade)
            : Person7(FirstName, LastName);
        public record Student(string FirstName, string LastName, int Grade)
            : Person7(FirstName, LastName);
        public static void EqualityInInheritanceDemo()
        {
            Person7 teacher = new Teacher2("Nancy", "Davolio", 3);
            Person7 student = new Student("Nancy", "Davolio", 3);
            Console.WriteLine($"Teacher: {teacher}");
            Console.WriteLine($"Student: {student}");

            Console.WriteLine($"teacher == student {teacher == student}"); // output: False

            Student student2 = new Student("Nancy", "Davolio", 3);
            Console.WriteLine($"Student2: {student2}");
            Console.WriteLine($"student2 == student {student2 == student}"); // output: True
        }

    }
}