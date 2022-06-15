namespace Delegates
{
    public class Program
    {
        static void Main()
        {
            MyDelegate.Del msgDel = ShowMessage;
            msgDel("Hi there!");

            MethodWithCallback(10, 20, msgDel);

            Console.WriteLine("One delegate invoking multiple methods, a.k.a. Mutlicast Delegates...");
            var obj = new MyMethodClass();
            MyDelegate.Del d1 = obj.Method1;
            MyDelegate.Del d2 = obj.Method2;
            MyDelegate.Del d3 = ShowMessage;

            Console.WriteLine($"Methods in d1: {d1.GetInvocationList().GetLength(0)}");
            Console.WriteLine($"Methods in d2: {d2.GetInvocationList().GetLength(0)}");
            Console.WriteLine($"Methods in d3: {d3.GetInvocationList().GetLength(0)}");

            MyDelegate.Del allMethods = d1 + d2;
            allMethods += d3;
            allMethods.Invoke("Hellooooo.");
            Console.WriteLine($"Methods in allMethods: {allMethods.GetInvocationList().GetLength(0)}");

            // Remove a method.
            Console.WriteLine("Remove a method from the delegate...");
            allMethods -= d1;
            allMethods.Invoke("Hellooooo again.");
            Console.WriteLine($"Methods in allMethods: {allMethods.GetInvocationList().GetLength(0)}");

            // Copy while removing d2.
            Console.WriteLine("Copy while removing d2...");
            MyDelegate.Del oneMethodDelegate = allMethods -= d2;
            oneMethodDelegate.Invoke("Hellooooo once again.");
            Console.WriteLine($"Methods in allMethods: {allMethods.GetInvocationList().GetLength(0)}");
            Console.WriteLine($"Methods in oneMethodDelegate: {oneMethodDelegate.GetInvocationList().GetLength(0)}");

            // With numbers.
            MyDelegate.AddNumbers addDel = Sum;
            addDel(10, 25);

            MyDelegate.SubtractNumbers subDel = Subtract;
            subDel(100, 25);

            // Multicast Delegate.
            MulticastDeleteDemo();

            // Func Delegate.
            FuncDelegateDemo();
        }

        // Func Delegate.
        static void FuncDelegateDemo()
        {
            FuncDelegateNormal.Go();
            FuncDelegate.Go();
        }

        static void MulticastDeleteDemo()
        {
            Console.WriteLine("\n\nMulticastDeleteDemo...");
            Rectangle rect = new Rectangle();

            // These two lines are normal calling of that two methods
            Console.WriteLine("Normal calling of the methods...");
            rect.area(6.3, 4.2);
            rect.perimeter(6.3, 4.2);
            Console.WriteLine();

            // Creating delegate object, name as "rectdele"
            // and pass the method as parameter by class object "rect"
            Rectangle.rectDelegate rectdele = new Rectangle.rectDelegate(rect.area);

            // Also can be written as:
            // rectDelegate rectdele = rect.area;

            // Call 2nd method "perimeter"
            // Multicasting
            rectdele += rect.perimeter;

            // Pass the values in two method by using "Invoke" method
            Console.WriteLine("Invoke the Delegate methods...");
            rectdele.Invoke(6.3, 4.2);
            Console.WriteLine();

            // Call the methods with different values
            Console.WriteLine("Invoke the Delegate methods with different numbers...");
            rectdele.Invoke(16.3, 10.3);
        }
        static void MethodWithCallback(int p1, int p2, MyDelegate.Del callback)
        {
            callback($"The number is: {p1 + p2}");
        }

        static void ShowMessage(string msg)
        {
            Console.WriteLine($"ShowMessage: {msg}");
        }

        static void Sum(int a, int b)
        {
            Console.WriteLine($"{a} + {b} = {a + b}");
        }

        static void Subtract(int a, int b)
        {
            Console.WriteLine($"{a} - {b} = {a - b}");
        }
    }
}