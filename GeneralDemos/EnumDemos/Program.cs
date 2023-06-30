using System;

namespace EnumDemos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //EnumDescriptionDemo(Status.New);
            //EnumDescriptionDemo(Status.InProgress);
            //EnumDescriptionDemo(Status.Approved);
            //EnumDescriptionDemo(Status.Rejected);
            //var myEnumDescriptions =
            //    from Status n in Enum.GetValues(typeof(Status))
            //    select new
            //    {
            //        ID = (int)n,
            //        Name = MyEnums.GetEnumDescription(n)
            //    };
            //myEnumDescriptions
            //    .ToList()
            //    .ForEach(a => Console.WriteLine(a));

            //GetEnumFromValue(0);
            //GetEnumFromValue(1);
            //GetEnumFromValue(2);
            //GetEnumFromValue(3);

            //EnumFlagsDemo1();
            //EnumFlagsDemo2();
            //PhoneServiceEnumFlags();
            ColorsEnumFlagsDemo();

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

        enum Suits { Spades = 1, Clubs = 2, Diamonds = 4, Hearts = 8 }
        [Flags] enum SuitsFlags { Spades = 1, Clubs = 2, Diamonds = 4, Hearts = 8 }
        static void EnumFlagsDemo1()
        {
            Console.WriteLine();
            Console.WriteLine("EnumFlagsDemo1()...");

            var str1 = (Suits.Spades | Suits.Diamonds).ToString();
            Console.WriteLine($"Without [Flags]: {str1}");   // "5"
            var str2 = (SuitsFlags.Spades | SuitsFlags.Diamonds).ToString();
            Console.WriteLine($"With [Flags]: {str2}");      // "Spades, Diamonds"
        }

        // Define an Enum without FlagsAttribute.
        enum SingleHue : short
        {
            None = 0,
            Black = 1,
            Red = 2,
            Green = 4,
            Blue = 8
        };

        // Define an Enum with FlagsAttribute.
        [Flags]
        enum MultiHue : short
        {
            None = 0,
            Black = 1,
            Red = 2,
            Green = 4,
            Blue = 8
        };

        static void EnumFlagsDemo2()
        {
            Console.WriteLine();
            Console.WriteLine("EnumFlagsDemo1()...");

            // Display all possible combinations of values.
            Console.WriteLine(
                    "All possible combinations of values without FlagsAttribute:");
            for (int val = 0; val <= 16; val++)
                Console.WriteLine("{0,3} - {1:G}", val, (SingleHue)val);

            // Display all combinations of values, and invalid values.
            Console.WriteLine(
                    "\nAll possible combinations of values with FlagsAttribute:");
            for (int val = 0; val <= 16; val++)
                Console.WriteLine("{0,3} - {1:G}", val, (MultiHue)val);
        }

        [Flags]
        public enum PhoneService
        {
            None = 0,
            LandLine = 1,
            Cell = 2,
            Fax = 4,
            Internet = 8,
            Other = 16
        }
        static void PhoneServiceEnumFlags()
        {
            // Define three variables representing the types of phone service
            // in three households.
            var household1 = PhoneService.LandLine | PhoneService.Cell |
                                PhoneService.Internet;
            var household2 = PhoneService.None;
            var household3 = PhoneService.Cell | PhoneService.Internet;

            // Store the variables in an array for ease of access.
            PhoneService[] households = { household1, household2, household3 };

            // Which households have no service?
            for (int ctr = 0; ctr < households.Length; ctr++)
                Console.WriteLine("Household {0} has phone service: {1}",
                                    ctr + 1,
                                    households[ctr] == PhoneService.None ?
                                        "No" : "Yes");
            Console.WriteLine();

            // Which households have cell phone service?
            for (int ctr = 0; ctr < households.Length; ctr++)
                Console.WriteLine("Household {0} has cell phone service: {1}",
                                    ctr + 1,
                                    (households[ctr] & PhoneService.Cell) == PhoneService.Cell ?
                                        "Yes" : "No");
            Console.WriteLine();

            // Which households have cell phones and land lines?
            var cellAndLand = PhoneService.Cell | PhoneService.LandLine;
            for (int ctr = 0; ctr < households.Length; ctr++)
                Console.WriteLine("Household {0} has cell and land line service: {1}",
                                    ctr + 1,
                                    (households[ctr] & cellAndLand) == cellAndLand ?
                                        "Yes" : "No");
            Console.WriteLine();

            // List all types of service of each household?//
            for (int ctr = 0; ctr < households.Length; ctr++)
                Console.WriteLine("Household {0} has: {1:G}",
                                    ctr + 1, households[ctr]);
            Console.WriteLine();
        }

        [Flags]
        enum ColorWithFlag : int
        {
            None = 0,
            Black = 1,
            Red = 2,
            Green = 4,
            Blue = 8,
            ThisColorIsSoRare = 268435456
        };
        enum ColorWithFlagLeftShifOp : int
        {
            None = 0,
            Black = 1,
            Red = 1 << 1,                   // 2
            Green = 1 << 2,                 // 4
            Blue = 1 << 3,                  // 8
            ThisColorIsSoRare = 1 << 60     // 268435456
        };
        static void ColorsEnumFlagsDemo()
        {
            // Group all the primary colors (i.e. red, blue, and green) into one variable.
            // This sums the integer representation of the color in the `primaryColors` variable,
            var primaryColors = ColorWithFlag.Red | ColorWithFlag.Green |
                                ColorWithFlag.Blue;
            //var primaryColors = ColorWithFlagLeftShifOp.Red | ColorWithFlagLeftShifOp.Green |
            //                    ColorWithFlagLeftShifOp.Blue;

            // So if you do:
            Console.WriteLine($"Regular: {primaryColors}");
            // You get Red, Green, Blue.

            // And if you do:
            var primaryColorsIntegerValue = (int)primaryColors;
            //you would get 14
            Console.WriteLine($"Number: {primaryColorsIntegerValue}");

            // This returns true.
            var isGreenColor = primaryColors.HasFlag(ColorWithFlag.Green) ? "Yes" : "No";
            Console.WriteLine($"Does it have Green color? {isGreenColor}");

            // This returns true.
            var isGreenAndRedColor = (primaryColors.HasFlag(ColorWithFlag.Green) |
                primaryColors.HasFlag(ColorWithFlag.Red)) ? "Yes" : "No";
            Console.WriteLine($"Does it have Green and Red colors? {isGreenAndRedColor}");

            // This returns false.
            var isBlackColor = primaryColors.HasFlag(ColorWithFlag.Black) ? "Yes" : "No";
            Console.WriteLine($"Does it have Black color? {isBlackColor}");

            // This returns false.
            var isGreenBlackAndRedColor = ((primaryColors.HasFlag(ColorWithFlag.Green) |
                primaryColors.HasFlag(ColorWithFlag.Red)) &
                primaryColors.HasFlag(ColorWithFlag.Black)) ? "Yes" : "No";
            Console.WriteLine($"Does it have Green or Red and Black colors? {isGreenBlackAndRedColor}");
        }
    }
}