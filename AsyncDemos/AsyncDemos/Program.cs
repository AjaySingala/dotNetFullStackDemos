using System;

namespace AsyncDemos
{
    public class Program
    {
        //public static void Main(string[] args)
        public async static Task Main(string[] args)
        {
            Console.WriteLine("Starting Async Demos...");

            //int length = GetUrlContentLengthAsync().Result;
            int length = await GetUrlContentLengthAsync();
            Console.WriteLine($"Length of content is {length}");

            Console.WriteLine("Finishing Async Demos...");
        }

        static async Task<int> GetUrlContentLengthAsync()
        {
            var client = new HttpClient();

            Task<string> getStringTask =
                client.GetStringAsync("https://docs.microsoft.com/dotnet");

            DoIndependentWork();

            string contents = await getStringTask;
            Console.WriteLine("This is after await getStringTask...");

            return contents.Length;
        }

        static void DoIndependentWork()
        {
            Console.WriteLine("Working...");
            //Thread.Sleep(5000);
        }
    }
}