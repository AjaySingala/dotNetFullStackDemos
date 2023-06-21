namespace EnumDemos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EnumDescriptionDemo(Status.New);
            EnumDescriptionDemo(Status.InProgress);
            EnumDescriptionDemo(Status.Approved);
            EnumDescriptionDemo(Status.Rejected);
            var myEnumDescriptions =
                from Status n in Enum.GetValues(typeof(Status))
                select new
                {
                    ID = (int)n,
                    Name = MyEnums.GetEnumDescription(n)
                };
            myEnumDescriptions
                .ToList()
                .ForEach(a => Console.WriteLine(a));

            GetEnumFromValue(0);
            GetEnumFromValue(1);
            GetEnumFromValue(2);
            GetEnumFromValue(3);

        }

        static void EnumDescriptionDemo(Status status)
        {
            Console.WriteLine("\n EnumDescriptionDemo()...");
            Console.WriteLine($"Status is {status}");
            Console.WriteLine($"Description is {MyEnums.GetEnumDescription(status)}");
            Console.WriteLine($"Name is {MyEnums.GetDisplayName(status)}");
            Console.WriteLine($"EnumMember Value is {MyEnums.GetEnumMemberValue(status)}");
        }

        static void GetEnumFromValue(int num)
        {
            Console.WriteLine("\n GetEnumFromValue()...");
            Status status = (Status)num;
            Console.WriteLine($"Status is {status}");
            Console.WriteLine($"Description is {MyEnums.GetEnumDescription(status)}");
            Console.WriteLine($"Name is {MyEnums.GetDisplayName(status)}");
            Console.WriteLine($"EnumMember Value is {MyEnums.GetEnumMemberValue(status)}");
        }

    }
}