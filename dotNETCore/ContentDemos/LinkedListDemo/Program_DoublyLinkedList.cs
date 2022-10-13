using System;

//DoublyDoublyLinkedListNode structure
class DoublyDoublyLinkedListNode
{
    public int data;
    public DoublyDoublyLinkedListNode next;
    public DoublyDoublyLinkedListNode prev;
};

class DoublyLinkedList
{
    public DoublyDoublyLinkedListNode head;
    //constructor to create an empty DoublyLinkedList
    public DoublyLinkedList()
    {
        head = null;
    }

    //display the content of the list
    public void PrintList()
    {
        DoublyDoublyLinkedListNode temp = new DoublyDoublyLinkedListNode();
        temp = this.head;
        if (temp != null)
        {
            Console.Write("The list contains: ");
            while (temp != null)
            {
                Console.Write(temp.data + " ");
                temp = temp.next;
            }
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("The list is empty.");
        }
    }

    //display the content of the list in reverse order.
    public void PrintReverseList()
    {
        Console.Write("The list in reverse contains: ");

        DoublyDoublyLinkedListNode tail = new DoublyDoublyLinkedListNode();
        tail = this.head;

        // Traversing till tail of the linked list.
        while (tail.next != null)
        {
            tail = tail.next;
        }

        // Traversing linked list from tail to head, and printing the node.data.
        while (tail != head)
        {
            Console.Write(tail.data + " ");
            tail = tail.prev;
        }
        Console.WriteLine(tail.data);
    }
};

// test the code 
class Implementation
{
    static void Main_DLL(string[] args)
    {
        //create an empty DoublyLinkedList 
        DoublyLinkedList MyList = new DoublyLinkedList();

        //Add first DoublyDoublyLinkedListNode.
        DoublyDoublyLinkedListNode first = new DoublyDoublyLinkedListNode();
        first.data = 10;
        first.next = null;
        first.prev = null;
        //linking with head DoublyDoublyLinkedListNode
        MyList.head = first;

        //Add second DoublyDoublyLinkedListNode.
        DoublyDoublyLinkedListNode second = new DoublyDoublyLinkedListNode();
        second.data = 20;
        second.next = null;
        //linking with first DoublyDoublyLinkedListNode
        second.prev = first;
        first.next = second;

        //Add third DoublyDoublyLinkedListNode.
        DoublyDoublyLinkedListNode third = new DoublyDoublyLinkedListNode();
        third.data = 30;
        third.next = null;
        //linking with second DoublyDoublyLinkedListNode
        third.prev = second;
        second.next = third;

        //print the content of list
        MyList.PrintList();

        //print the content of list in reverse.
        MyList.PrintReverseList();
    }
}