// C# program to illustrate queue
using System;
using System.Collections;

public class Program
{
    static public void Main_Q()
    {

        // Create a queue
        // Using Queue class
        Queue my_queue = new Queue();

        // Adding elements in Queue
        // Using Enqueue() method
        my_queue.Enqueue("Ajay Singala");
        my_queue.Enqueue(1);
        my_queue.Enqueue(100);
        my_queue.Enqueue(null);
        my_queue.Enqueue(2.4);
        my_queue.Enqueue("Ajay123");

        // Accessing the elements of my_queue Queue using foreach loop.
        foreach (var ele in my_queue)
        {
            Console.WriteLine(ele);
        }

        Console.WriteLine("Total elements present in my_queue: {0}",
                                                    my_queue.Count);

        // Obtain the topmost element of my_queue using Dequeue method
        Console.WriteLine("Topmost element of my_queue"
                     + " is: {0}", my_queue.Dequeue());


        Console.WriteLine("Total elements present in my_queue: {0}",
                                                    my_queue.Count);

        // Obtain the topmost element of my_queue using Peek method
        Console.WriteLine("Topmost element of my_queue is: {0}",
                                               my_queue.Peek());

        Console.WriteLine("Total elements present in my_queue: {0}",
                                                    my_queue.Count);

        //// Delete / Remove.
        //my_queue.Dequeue();

        //// After Dequeue method
        //Console.WriteLine("Total elements present in my_queue: {0}",
        //                                            my_queue.Count);

        //// Remove all the elements from the queue
        //my_queue.Clear();

        //// After Clear method
        //Console.WriteLine("Total elements present in my_queue: {0}",
        //                                            my_queue.Count);
    }
}