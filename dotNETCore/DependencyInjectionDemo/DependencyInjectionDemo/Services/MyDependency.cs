using DependencyInjectionDemo.Interfaces;

namespace DependencyInjectionDemo.Services
{
    public class MyDependency : IMyDependency
    {
        public void WriteMessage(string message)
        {
            Console.WriteLine($"MyDependency.WriteMessage Message: {message}");
        }
    }
}
