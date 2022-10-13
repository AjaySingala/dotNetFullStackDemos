namespace StackDemos
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<string> stack1 = new Stack<string>();
            string[] str = {
                "MCA",
                "BCA",
                "BBA",
                "MBA",
                "MTech"
            };
            Stack<string> stack2 = new Stack<string>(str);
            Stack<string> stack3 = new Stack<string>(10);
            stack1.Push("************");
            stack1.Push("MCA");
            stack1.Push("MBA");
            stack1.Push("BCA");
            stack1.Push("BBA");
            stack1.Push("***********");
            stack1.Push("**Courses**");
            stack1.Push("***********");
            Console.WriteLine("The elements in the stack1 are as:");
            foreach (string s in stack1)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine("The elements in the stack2 are as:");
            foreach (string s in stack2)
            {
                Console.WriteLine(s);
            }
            stack3.Push("one");
            stack3.Push("Two");
            Console.WriteLine("The elements in the stack3 are as:");
            foreach (string s in stack3)
            {
                Console.WriteLine(s);
            }
        }
    }
}