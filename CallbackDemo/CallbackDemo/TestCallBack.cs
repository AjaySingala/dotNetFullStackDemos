using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CallbackDemo.CallBack;

namespace CallbackDemo
{
    public class TestCallBack
    {
        public void Test()
        {
            TaskCompletedCallBack callbackMethod = MyCallback;
            CallBack cb = new CallBack();
            Console.WriteLine("Initiating call to start new task...");
            cb.StartNewTask(MyCallback);        // Directly give the function name.
            cb.StartNewTask(callbackMethod);    // via the delegate.

            cb.StartNewTask(AnotherCallback);

            //cb.StartNewTask(FaultyCallback);
        }

        public void MyCallback(string msg)
        {
            Console.WriteLine($"Recieved message '{msg}' from the task...");
        }

        public void AnotherCallback(string msg)
        {
            Console.WriteLine("This is AnotherCallback() method...");
            Console.WriteLine($"Recieved message '{msg}' from the task...");
        }

        public void FaultyCallback(int i)
        {
            Console.WriteLine("This is AnotherCallback() method...");
            Console.WriteLine($"Recieved message '{i}' from the task...");
        }
    }
}
