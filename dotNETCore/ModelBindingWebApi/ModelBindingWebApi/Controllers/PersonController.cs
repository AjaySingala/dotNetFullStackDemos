using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelBindingWebApi.Models;

namespace ModelBindingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[BindProperties(SupportsGet = true)]      // For GET.
    //[BindProperties]                          // For POST.
    public class PersonController : ControllerBase
    {
        // For GET methods, use [BindProperty(SupportsGet =true)].
        // For POST method, use [BindProperty].
        //[BindProperty(SupportsGet =true)]
        //[BindProperty()]
        public string Name { get; set; }
        //[BindProperty(SupportsGet = true)]
        //[BindProperty()]
        public int Age { get; set; }

        //[HttpGet]
        //public string Get()
        //{
        //    Console.WriteLine($"Person.Get()...");

        //    return "person";
        //}

        // api/person?name=ajay&age=28
        [HttpGet]
        [Route("process")]
        public Person Get(string name, int age)
        {
            Console.WriteLine($"Process: Name: {name}, Age: {age}");
            Person person = new Person()
            {
                Name = name,
                Age = age
            };

            return person;
        }

        // api/person
        [HttpGet]
        public ActionResult<Person> Get()
        {
            Console.WriteLine($"Process2: Name: {Name}, Age: {Age}");
            Person person = new Person()
            {
                Name = this.Name,
                Age = this.Age
            };

            return person;
        }

        // Use raw - JSON in Postman.
        // And comment [BindProperty] above.
        // api/person
        [HttpPost]
        //[Route("process3")]
        public int Post(Person person)
        {
            Console.WriteLine($"Process3: Name: {person.Name}, Age: {person.Age}");
            return person.Age;
        }

        // Use form-data in Postman.
        [HttpPost]
        [Route("process4")]
        public int Post()
        {
            Console.WriteLine($"Process4: Name: {Name}, Age: {Age}");
            return Age;
        }
    }
}
