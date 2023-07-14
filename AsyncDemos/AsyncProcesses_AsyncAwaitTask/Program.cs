namespace AsyncProcesses_AsyncAwaitTask
{
    internal class Program
    {
        static int x = 0;

        static async Task Main(string[] args)
        {
            var val = 0;
            Task<int> result = LongProcess();
            ShortProcess();

            // Display class level variable's value (before await).
            Console.WriteLine("x: {0}", x);

            val = await result; // Wait until you get the return value.

            // Display class level variable's value (after await).
            Console.WriteLine("x: {0}", x);

            // Displays after result is obtained, not early.
            Console.WriteLine("Result: {0}", val);
            Console.WriteLine("Press <ENTER> to continue...");
            //Console.ReadKey();
        }

        static async Task<int> LongProcess()
        {
            Console.WriteLine("LongProcess Started");
            await Task.Delay(4000); // hold execution for 4 seconds
            x = 20;                 // Update the class level variable's value.
            Console.WriteLine("LongProcess Completed");
            return 10;
        }

        static void ShortProcess()
        {
            Console.WriteLine("ShortProcess Started");
            //do something here
            Console.WriteLine("ShortProcess Completed");
        }
    }
}