using System;

//node structure
class SinglyLinkedListNode
{
    public int data;
    public SinglyLinkedListNode next;
};

class SinglyLinkedList
{
    public SinglyLinkedListNode head;
    //constructor to create an empty LinkedList
    public SinglyLinkedList()
    {
        head = null;
    }

    //display the content of the list
    public void PrintList()
    {
        SinglyLinkedListNode temp = new SinglyLinkedListNode();
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
};

// test the code 
class Program
{
    static void Main_SLL(string[] args)
    {
        //create an empty LinkedList
        SinglyLinkedList MyList = new SinglyLinkedList();

        //Add first node.
        SinglyLinkedListNode first = new SinglyLinkedListNode();
        first.data = 10;
        first.next = null;
        //linking with head node
        MyList.head = first;

        //Add second node.
        SinglyLinkedListNode second = new SinglyLinkedListNode();
        second.data = 20;
        second.next = null;
        //linking with first node
        first.next = second;

        //Add third node.
        SinglyLinkedListNode third = new SinglyLinkedListNode();
        third.data = 30;
        third.next = null;
        //linking with second node
        second.next = third;

        //print the content of list
        MyList.PrintList();
    }
}