namespace AsyncProcesses_AsyncAwait
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            LongProcess();
            ShortProcess();

            Console.WriteLine("Press <ENTER> to continue...");  // Displays early.
            //Console.ReadKey();
        }

        public static async void LongProcess()
        {
            Console.WriteLine("LongProcess Started");
            await Task.Delay(4000); // hold execution for 4 seconds
            Console.WriteLine("LongProcess Completed");
        }

        static void ShortProcess()
        {
            Console.WriteLine("ShortProcess Started");
            //do something here
            Console.WriteLine("ShortProcess Completed");
        }
    }
}