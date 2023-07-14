using System;

namespace EventDemo
{
    public delegate void DelEventHandler();

    internal class Program
    {
        public static event DelEventHandler events;

        static void Main(string[] args)
        {
            //EventDemo1();
            //EventDemo2();
            //EventNotifyDemo();
            PassEventDataDemo();

            Console.WriteLine("Press <ENTER> to continue...");
            Console.ReadLine();
        }

        #region Passing Event Data Demo

        // Event handler.
        public static void bl_ProcessCompletedWithData(object sender, ProcessEventArgs e)
        {
            Console.WriteLine("Process " + (e.IsSuccessful ? "Completed Successfully" : "Failed!!!"));
            Console.WriteLine("Completion Time: " + e.CompletionTime.ToLongDateString());
        }

        public static void PassEventDataDemo()
        {
            ProcessBusinessLogicWithData bl = new ProcessBusinessLogicWithData();
            bl.ProcessCompleted += bl_ProcessCompletedWithData; // Register with an event.
            bl.StartProcess();
        }

        #endregion

        #region Notify Event Demo

        // event handler.
        static void bl_ProcessCompleted()
        {
            Console.WriteLine("Process Completed!");
        }

        static void EventNotifyDemo()
        {
            ProcessBusinessLogic bl = new ProcessBusinessLogic();
            bl.ProcessCompleted += bl_ProcessCompleted; // register with an event.

            //// Register one more.
            //bl.ProcessCompleted += bl_AnotherProcessCompleted;

            bl.StartProcess();
        }

        // Another event handler.
        static void bl_AnotherProcessCompleted()
        {
            Console.WriteLine("Process Completed! [bl_AnotherProcessCompleted]");
        }
        #endregion

        #region Event Demo 2.

        public static void CatchEvent(string s)
        {
            Console.WriteLine("Method Calling");
        }

        static void EventDemo2()
        {
            Console.WriteLine();
            Console.WriteLine("EventDemo2()...,");

            EventDemo2 o = new EventDemo2();

            o.Action("Event Calling before event registration.");
            o.xyz += new EventDemo.EventDemo2.MyEventHandler(CatchEvent);
            o.Action("Event Calling Again after event registration.");
        }

        #endregion

        #region Event Demo 1.

        static void EventDemo1()
        {
            Console.WriteLine();
            Console.WriteLine("EventDemo1()...,");

            events += new DelEventHandler(USA);
            events += new DelEventHandler(India);
            events += new DelEventHandler(England);
            events.Invoke();
        }

        static void USA()
        {
            Console.WriteLine("USA");
        }

        static void India()
        {
            Console.WriteLine("India");
        }

        static void England()
        {
            Console.WriteLine("England");
        }

        #endregion
    }
}