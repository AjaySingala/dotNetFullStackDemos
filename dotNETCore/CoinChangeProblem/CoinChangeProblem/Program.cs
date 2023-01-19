namespace CoinChangeProblem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@"C:\Temp\coins.txt", true);

            string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

            int n = Convert.ToInt32(firstMultipleInput[0]);

            int m = Convert.ToInt32(firstMultipleInput[1]);

            List<long> c = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(cTemp => Convert.ToInt64(cTemp)).ToList();

            // Print the number of ways of making change for 'n' units using coins having the values given by 'c'

            long ways = Result.getWays(n, c);

            textWriter.WriteLine(ways);

            textWriter.Flush();
            textWriter.Close();
        }
    }

    class Result
    {

        /*
         * Complete the 'getWays' function below.
         *
         * The function is expected to return a LONG_INTEGER.
         * The function accepts following parameters:
         *  1. INTEGER n
         *  2. LONG_INTEGER_ARRAY c
         */

        public static long getWays(int n, List<long> c)
        {
            long[] ways = new long[(int)n + 1];
            //Set first way to 1 because if n is 0 there is only one way to get 0
            ways[0] = 1;

            //Going through all of the coins
            for (int i = 0; i < c.Count; i++)
            {

                //Going through the ways that have been done so far
                for (int j = 0; j < ways.Length; j++)
                {

                    //if coin at index i is <= j
                    if (c[i] <= j)
                    {

                        //then ways[j] += ways[index of j - coin at I index]
                        ways[j] += ways[(int)(j - c[i])];
                    }
                }
            }

            return ways[(int)n];
        }

    }
}