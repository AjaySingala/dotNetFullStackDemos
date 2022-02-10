using System;

namespace AsyncDemoTwo
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting Async Demo Two...");

            Method1();
            Method2();

            Console.WriteLine("Finishing Async Demo Two...");
            Console.ReadKey();
        }

        public static async Task Method1()
        {
            await Task.Run(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    Console.WriteLine($" Method 1 - {i}");
                    // Do something
                    Task.Delay(100).Wait();
                }
            });
        }


        public static void Method2()
        {
            for (int i = 0; i < 25; i++)
            {
                Console.WriteLine($" Method 2 - {i}");
                // Do something
                Task.Delay(100).Wait();
            }
        }
    }
}
