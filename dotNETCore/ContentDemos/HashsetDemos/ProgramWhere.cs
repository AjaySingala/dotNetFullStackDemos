using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashsetDemos
{
    class ProgramWhere
    {
		static void Main_PW()
		{
			// Creating a HashSet of integers.
			HashSet<int> mySet = new HashSet<int>();

			// Inserting elements into HashSet.
			for (int i = 0; i < 10; i++)
			{
				mySet.Add(i);
			}

			// Displaying the number of elements in HashSet
			Console.WriteLine("Before: Number of elements are : " + mySet.Count);

			// Remove elements from a HashSet with conditions defined by the predicate.
			mySet.RemoveWhere(isEven);

			// Displaying the number of elements in HashSet
			Console.WriteLine("After: Number of elements are : " + mySet.Count);
		}

		// Helper function which tells whether an element is even or not.
		private static bool isEven(int i)
		{
			return ((i % 2) == 0);
		}
	}
}
