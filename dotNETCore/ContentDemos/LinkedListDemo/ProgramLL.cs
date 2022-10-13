using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineApp
{
	class ProgramLinkedList
	{
		static void Main(string[] args)
		{

			// initialization and filling of the linked list
			LinkedList<int> list = new LinkedList<int>();
			list.AddLast(1);
			list.AddLast(2);
			LinkedListNode<int> middle = list.AddLast(3);
			list.AddLast(4);
			list.AddLast(5);

			// adding and deleting in the middle of the list
			list.AddAfter(middle, 32);
			list.AddAfter(middle, 31);
			list.Remove(middle);

			// printing the list
			foreach (int i in list)
				Console.Write("{0}, ", i);

			Console.ReadKey();
		}
	}
}