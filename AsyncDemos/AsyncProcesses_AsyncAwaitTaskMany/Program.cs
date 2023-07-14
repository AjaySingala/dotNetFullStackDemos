namespace AsyncProcesses_AsyncAwaitTaskMany
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Task<int> result1 = LongProcess1();
            Task<int> result2 = LongProcess2();
            
            // Do something here.
            // Displays before results are obtained.
            Console.WriteLine("After two long processes.");

            // Wait for the processes to complete and results returned.
            int val = await result1;    // Wait until get the return value.
            DisplayResult(val);         // Displays after result is obtained.
            val = await result2;        // Wait until get the return value.
            DisplayResult(val);         // Displays after result is obtained.

            // Displays after result are obtained.
            Console.WriteLine("Press any key to continue...");
            //Console.ReadKey();
        }

        static async Task<int> LongProcess1()
        {
            Console.WriteLine("LongProcess 1 Started");
            await Task.Delay(10000); // hold execution for 10 seconds
            Console.WriteLine("LongProcess 1 Completed");
            return 10;
        }

        static async Task<int> LongProcess2()
        {
            Console.WriteLine("LongProcess 2 Started");
            await Task.Delay(4000); // hold execution for 4 seconds
            Console.WriteLine("LongProcess 2 Completed");
            return 20;
        }

        static void DisplayResult(int val)
        {
            Console.WriteLine(val);
        }
    }
}