// C# program to illustrate how to create a LinkedList
using System;
using System.Collections.Generic;

class Program_CSharpLinkedList
{

    // Main Method
    static public void MainCSharpLL()
    {

        // Creating a linkedlist
        // Using LinkedList class
        LinkedList<String> my_list = new LinkedList<String>();

        // Adding elements in the LinkedList
        // Using AddLast() method
        my_list.AddLast("Zoya");
        my_list.AddLast("Sherry");
        my_list.AddLast("Rachel");
        my_list.AddLast("Rohan");
        my_list.AddLast("Jerry");
        my_list.AddLast("Zoya");

        Console.WriteLine("Best students of XYZ university:");

        // Accessing the elements of 
        // LinkedList Using foreach loop
        foreach (string str in my_list)
        {
            Console.WriteLine(str);
        }

        // After using Remove(LinkedListNode)
        // method
        Console.WriteLine("\nBest students of XYZ" +
                         " university in 2000:");

        my_list.Remove(my_list.First);

        foreach (string str in my_list)
        {
            Console.WriteLine(str);
        }

        // After using Remove(T) method
        Console.WriteLine("\nBest students of XYZ" +
                         " university in 2001:");

        my_list.Remove("Rachel");

        foreach (string str in my_list)
        {
            Console.WriteLine(str);
        }

        // After using RemoveFirst() method
        Console.WriteLine("\nBest students of XYZ" +
                         " university in 2002:");

        my_list.RemoveFirst();

        foreach (string str in my_list)
        {
            Console.WriteLine(str);
        }

        // After using RemoveLast() method
        Console.WriteLine("\nBest students of XYZ" +
                         " university in 2003:");

        my_list.RemoveLast();

        foreach (string str in my_list)
        {
            Console.WriteLine(str);
        }

        // After using Clear() method
        my_list.Clear();
        Console.WriteLine("\nNumber of students: {0}",
                                     my_list.Count);
    }
}