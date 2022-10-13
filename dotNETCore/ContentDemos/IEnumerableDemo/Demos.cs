using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEnumerableDemo
{
    public class MyCollection : IEnumerable
    {
        int[] data = { 1, 2, 3 };

        public IEnumerator GetEnumerator()
        {
            foreach (int i in data)
                yield return i;
        }
    }

    public class MyIntList : IEnumerable
    {
        int[] data = { 1, 2, 3 };

        public IEnumerator GetEnumerator()
        {
            Console.WriteLine("Inside GetEnumerator()...");
            return new Enumerator(this);
        }

        class Enumerator : IEnumerator       // Define an inner class for the enumerator.
        {
            MyIntList collection;
            int currentIndex = -1;

            public Enumerator(MyIntList collection)
            {
                this.collection = collection;
            }

            public object Current
            {
                get
                {
                    if (currentIndex == -1)
                        throw new InvalidOperationException("Enumeration not started!");
                    if (currentIndex == collection.data.Length)
                        throw new InvalidOperationException("Past end of list!");
                    return collection.data[currentIndex];
                }
            }

            public bool MoveNext()
            {
                Console.WriteLine("Inside MoveNext()...");
                if (currentIndex >= collection.data.Length - 1)
                    return false;
                return ++currentIndex < collection.data.Length;
            }

            public void Reset() { currentIndex = -1; }
        }
    }

    public class MyIntListGen : IEnumerable<int>
    {
        int[] data = { 1, 2, 3 };

        public IEnumerator<int> GetEnumerator()
        {
            Console.WriteLine("Inside IEnumerable<int> GetEnumerator()...");
            return new Enumerator(this);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            Console.WriteLine("Inside IEnumerable.GetEnumerator()...");
            return new Enumerator(this);
        }

        class Enumerator : IEnumerator<int>       // Define an inner class for the enumerator.
        {
            MyIntListGen collection;
            int currentIndex = -1;

            public Enumerator(MyIntListGen collection)
            {
                this.collection = collection;
            }

            public int Current
            {
                get
                {
                    if (currentIndex == -1)
                        throw new InvalidOperationException("Enumeration not started!");
                    if (currentIndex == collection.data.Length)
                        throw new InvalidOperationException("Past end of list!");
                    return collection.data[currentIndex];
                }
            }

            object IEnumerator.Current => Current;

            public void Dispose() { }

            public bool MoveNext()
            {
                Console.WriteLine("Inside MoveNext()...");
                if (currentIndex >= collection.data.Length - 1)
                    return false;
                return ++currentIndex < collection.data.Length;
            }

            public void Reset() { currentIndex = -1; }
        }
    }


}

