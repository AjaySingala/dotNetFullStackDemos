using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // [Produces("application/json")]
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

        // /// <summary>
        // /// Gets a Person's name and age.
        // /// </summary>
        // /// <param name="name"></param>
        // /// <param name="age"></param>
        // /// <returns>A Person object</returns>
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

        // /// <summary>
        // /// Gets a Person's name and age.
        // /// </summary>
        // /// <returns>A Person object</returns>
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

        //[Route("process3")]
        // /// <summary>
        // /// Creates a Person.
        // /// </summary>
        // /// <param name="person"></param>
        // /// <returns>A newly created TodoItem</returns>
        // /// <remarks>
        // /// Sample request:
        // ///    POST /api/Person
        // ///    {
        // ///       "name": "ajay",
        // ///       "age": 26
        // ///    }
        // /// </remarks>
        // /// <response code="201">Returns the newly created item</response>
        // /// <response code="400">If the item is null</response>
        // [ProducesResponseType(StatusCodes.Status201Created)]
        // [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public int Post(Person person)
        {
            Console.WriteLine($"Process3: Name: {person.Name}, Age: {person.Age}");
            return person.Age;
        }
    }
}
