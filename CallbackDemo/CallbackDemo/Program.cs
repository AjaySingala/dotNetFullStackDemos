namespace CallbackDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting Callback demo...");
            TestCallBack testCallBack = new TestCallBack();
            testCallBack.Test();

            Console.WriteLine("Press <ENTER> to continue...");
            Console.ReadLine();
        }
    }
}