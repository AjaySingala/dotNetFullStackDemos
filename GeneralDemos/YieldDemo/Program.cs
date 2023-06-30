using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace YieldDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //YieldDemo();
            //IteratorWithoutLocalExample();
            //IteratorWithLocalExample();

            //var vals = SequenceToLowercase(new List<string> { "ONE", "Two", "THREE"});
            //foreach( var val in vals)
            //{
            //    Console.WriteLine(val);
            //}
        }

        static void YieldDemo()
        {
            var nums = GetNumberArray();
            //var nums = GetNumberArrayWithYield();
            foreach (var n in nums)
            {
                Console.WriteLine(n);
            }
        }

        static int[] GetNumberArray()
        {
            int[] nums = new int[10];
            for (int i = 0; i < 10; i++)
            {
                if (i % 2 == 0)
                {
                    // ???
                }
            }
            return nums;
        }

        //static IEnumerable<int> GetNumberArrayWithYield()
        static IEnumerable<int> GetNumberArrayWithYield()
        {
            for (int i = 0; i < 10; i++)
            {
                if (i % 2 == 0)
                {
                    yield return i;
                }
            }
        }

        static void IteratorWithoutLocalExample()
        {
            IEnumerable<int> xs = OddSequence(50, 110);
            Console.WriteLine("Retrieved enumerator...");

            foreach (var x in xs)  // line 11
            {
                Console.Write($"{x} ");
            }
        }

        static IEnumerable<int> OddSequence(int start, int end)
        {
            if (start < 0 || start > 99)
                throw new ArgumentOutOfRangeException(nameof(start), "start must be between 0 and 99.");
            if (end > 100)
                throw new ArgumentOutOfRangeException(nameof(end), "end must be less than or equal to 100.");
            if (start >= end)
                throw new ArgumentException("start must be less than end.");

            for (int i = start; i <= end; i++)
            {
                if (i % 2 == 1)
                    yield return i;
            }
        }

        static void IteratorWithLocalExample()
        {
            IEnumerable<int> xs = OddSequence2(50, 110);
            Console.WriteLine("Retrieved enumerator...");

            foreach (var x in xs)  // line 11
            {
                Console.Write($"{x} ");
            }
        }

        static IEnumerable<int> OddSequence2(int start, int end)
        {
            if (start < 0 || start > 99)
                throw new ArgumentOutOfRangeException(nameof(start), "start must be between 0 and 99.");
            if (end > 100)
                throw new ArgumentOutOfRangeException(nameof(end), "end must be less than or equal to 100.");
            if (start >= end)
                throw new ArgumentException("start must be less than end.");

            return GetOddSequenceEnumerator();

            IEnumerable<int> GetOddSequenceEnumerator()
            {
                for (int i = start; i <= end; i++)
                {
                    if (i % 2 == 1)
                        yield return i;
                }
            }
        }

        static public IEnumerable<string> SequenceToLowercase(IEnumerable<string> input)
        {
            if (!input.Any())
            {
                throw new ArgumentException("There are no items to convert to lowercase.");
            }

            return LowercaseIterator();

            IEnumerable<string> LowercaseIterator()
            {
                foreach (var output in input.Select(item => item.ToLower()))
                {
                    yield return output;
                }
            }
        }

    }
}