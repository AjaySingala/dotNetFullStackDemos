using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallbackDemo
{
    public class CallBack
    {
        public delegate void TaskCompletedCallBack(string message);

        public void StartNewTask(TaskCompletedCallBack callback)
        {
            Console.WriteLine("Starting new task....");
            callback("Done processing! Going to Callback method.");
        }
    }
}
