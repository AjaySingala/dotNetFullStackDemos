using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDemo
{
    public class ProcessEventArgs : EventArgs
    {
        public bool IsSuccessful { get; set; }
        public DateTime CompletionTime { get; set; }
    }

    public class ProcessBusinessLogicWithData
    {
        // Declaring an event using built-in EventHandler.
        public event EventHandler<ProcessEventArgs> ProcessCompleted;

        public void StartProcess()
        {
            var data = new ProcessEventArgs();

            try
            {
                Console.WriteLine("Process Started!");

                // some code here..
var rnd = new Random();
var divisor = rnd.Next(0, 2);
var dividend = rnd.Next(1, 100);
Console.WriteLine($"Dividing {dividend} by {divisor}");

var result = dividend / divisor;

                data.IsSuccessful = true;
                data.CompletionTime = DateTime.Now;
                OnProcessCompleted(data);
            }
            catch (Exception ex)
            {
                data.IsSuccessful = false;
                data.CompletionTime = DateTime.Now;
                OnProcessCompleted(data);
            }
        }

        protected virtual void OnProcessCompleted(ProcessEventArgs e)
        {
            ProcessCompleted?.Invoke(this, e);
        }
    }
}
