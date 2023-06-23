using System.ComponentModel.DataAnnotations;

namespace YieldDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            YieldDemo();
        }

        static void YieldDemo()
        {
            //var nums1 = GetNumberArray();
            var nums2 = GetNumberArrayWithYield();
            foreach(var n in nums2)
            {
                Console.WriteLine(n);
            }
        }

        static int[] GetNumberArray()
        {
            int[] nums = new int[10];
            for(int i = 0; i < 10; i++)
            {
                if(i % 2 == 0)
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

    }
}