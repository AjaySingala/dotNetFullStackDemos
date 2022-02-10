using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        //[BindProperty(SupportsGet =true)]
        public string Name { get; set; }
        //[BindProperty(SupportsGet = true)]
        public int Age { get; set; }

        //[HttpGet]
        //public string Get()
        //{
        //    Console.WriteLine($"Person.Get()...");

        //    return "person";
        //}

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

        [HttpPost]
        //[Route("process3")]
        public int Post(Person person)
        {
            Console.WriteLine($"Process3: Name: {person.Name}, Age: {person.Age}");
            return person.Age;
        }
    }
}
