using System;

namespace AsyncDemoThree
{
    public class Program
    {
        //static void Main(string[] args)         // For C#7.
        static async Task Main(string[] args)     // For C#9.
        {
            Console.WriteLine("Starting Async Demo Three...");

            //callMethod();             // For C#7
            await callMethod2();        // For C#9

            Console.WriteLine("Finishing Async Demo Three...");
            Console.ReadKey();
        }

        // For C#7.
        public static async void callMethod()
        {
            Task<int> task = Method1();
            Method2();
            int count = await task;
            Method3(count);
        }

        // For C#9.
        public static async Task callMethod2()
        {
            Task<int> task = Method1();
            Method2();
            int count = await task;
            Method3(count);
        }

        public static async Task<int> Method1()
        {
            int count = 0;
            await Task.Run(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    Console.WriteLine($" Method 1 - {i}");
                    count += 1;
                }
            });
            return count;
        }

        public static void Method2()
        {
            for (int i = 0; i < 25; i++)
            {
                Console.WriteLine($" Method 2 - {i}");
            }
        }

        public static void Method3(int count)
        {
            Console.WriteLine("Total count is " + count);
        }
    }
}
