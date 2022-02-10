using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    //[BindProperties(SupportsGet =true)]
    public class ModelBindingController : Controller
    {
        //[BindProperty(SupportsGet =true)]
        public string Name { get; set; }
        //[BindProperty(SupportsGet = true)]
        public int Age { get; set; }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Process(string name, int age)
        {
            Console.WriteLine($"Process: Name: {name}, Age: {age}");
            return View("Index");
        }

        public IActionResult Process2()
        {
            Console.WriteLine($"Process2: Name: {Name}, Age: {Age}");
            return View("Index");
        }

        public IActionResult Process3(Person person)
        {
            Console.WriteLine($"Process3: Name: {person.Name}, Age: {person.Age}");
            return View("Index");
        }

    }
}
