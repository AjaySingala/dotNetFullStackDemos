using System;

namespace AsyncFileIO
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting Async File I/O Demo...");

            Task task = new Task(CallMethod);
            task.Start();
            task.Wait();

            Console.WriteLine("Finishing Async File I/O Demo...");
            Console.ReadLine();
        }

        static async void CallMethod()
        {
            string filePath = @"C:\Temp\TheNotebooksofLeonardoDaVinci.txt";
            Task<int> task = ReadFile(filePath);

            Console.WriteLine(" Other Work 1");
            Console.WriteLine(" Other Work 2");
            Console.WriteLine(" Other Work 3");

            int length = await task;
            Console.WriteLine(" Total length: " + length);

            Console.WriteLine(" After work 1");
            Console.WriteLine(" After work 2");
        }

        static async Task<int> ReadFile(string file)
        {
            int length = 0;

            Console.WriteLine(" File reading is starting");
            using (StreamReader reader = new StreamReader(file))
            {
                // Reads all characters from the current position to the end of
                // the stream asynchronously and returns them as one string.
                string s = await reader.ReadToEndAsync();
                
                //// Sleep just to show the delay.
                //Thread.Sleep(1000);

                length = s.Length;
            }
            Console.WriteLine(" File reading is completed");
            return length;
        }
    }
}