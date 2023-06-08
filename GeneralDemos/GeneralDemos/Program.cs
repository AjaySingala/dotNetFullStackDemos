namespace GeneralDemos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //IEnumerableDemo();
            //YieldDemo();
            //YieldBreakDemo();
            LambdaDemo();

            Console.WriteLine("\nPress <ENTER> to continue...");
            Console.ReadLine();
        }

        static void LambdaDemo()
        {
            ExpressionLambdaDemo();
            StatementLambdaDemo();
        }

        static void ExpressionLambdaDemo()
        {
            Console.WriteLine("\nExpressionLambdaDemo...");
            // expression lambda that returns the square of a number.
            var square = (int num) => num * num;


            // passing input to the expression lambda 
            Console.WriteLine("Square of number: " + square(5));
        }
        static void StatementLambdaDemo()
        {
            Console.WriteLine("\nStatementLambdaDemo...");
            // statement lambda that takes two int inputs and returns the sum.
            var resultingSum = (int a, int b) =>
            {
                int calculatedSum = a + b;
                return calculatedSum;
            };

            // find the sum of 5 and 6
            Console.WriteLine("Total sum: " + resultingSum(5, 6));
        }

        static void YieldDemo()
        {
            Console.WriteLine("\nYieldDemo...");
            foreach (int i in ProduceEvenNumbers(9))
            {
                Console.Write(i);
                Console.Write(" ");
            }
            // Output: 0 2 4 6 8
            Console.WriteLine();

            IEnumerable<int> ProduceEvenNumbers(int upto)
            {
                for (int i = 0; i <= upto; i += 2)
                {
                    yield return i;
                }
            }

        }

        static void YieldBreakDemo()
        {
            Console.WriteLine("\nYieldBreakDemo...");
            Console.WriteLine(string.Join(" ", TakeWhilePositive(new[] { 2, 3, 4, 5, -1, 3, 4 })));
            // Output: 2 3 4 5

            Console.WriteLine(string.Join(" ", TakeWhilePositive(new[] { 9, 8, 7 })));
            // Output: 9 8 7

            IEnumerable<int> TakeWhilePositive(IEnumerable<int> numbers)
            {
                foreach (int n in numbers)
                {
                    if (n > 0)
                    {
                        yield return n;
                    }
                    else
                    {
                        yield break;
                    }
                }
            }
        }

        static void IEnumerableDemo()
        {
            Console.WriteLine("\n Demo...");

            var customers = GetAllCustomers();
            foreach (var customer in customers)
            {
                Console.WriteLine(customer.Name);
            }
        }

        private static IEnumerable<Customer> GetAllCustomers()
        {
            Customer[] customers = new Customer[]
            {
                new Customer { Id = 1, Name = "John Smith", City = "Mumbai" },
                new Customer { Id = 2, Name = "Mary Jane", City = "Indore" },
                new Customer { Id = 3, Name = "Ethan Hunt", City = "Pune" },
                new Customer { Id = 4, Name = "Peter Quill", City = "Mumbai" },
                new Customer { Id = 5, Name = "Gus Sweet Tooth", City = "Delhi" }
            };
            return customers;
        }
    }
}