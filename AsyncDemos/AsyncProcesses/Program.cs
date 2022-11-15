using System;

namespace AsyncProcesses
{
    public class Program
    {
        static void Main(string[] args)
        {
            LongProcess();
            ShortProcess();
        }

        static void LongProcess()
        {
            Console.WriteLine("LongProcess Started");

            // Some code that takes long execution time. 
            System.Threading.Thread.Sleep(4000); // hold execution for 4 seconds.

            Console.WriteLine("LongProcess Completed");
        }

        static void ShortProcess()
        {
            Console.WriteLine("ShortProcess Started");
            // Do something here.
            Console.WriteLine("ShortProcess Completed");
        }
    }
}
