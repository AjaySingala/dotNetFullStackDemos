using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FilterDemos;
using FilterDemos.Models;
using Microsoft.AspNetCore.Authorization;

namespace FilterDemos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[SampleActionFilter]
    //[SampleActionFilterAsync]
    public class FilterController : ControllerBase
    {
        //[SampleActionFilter]
        public async Task<ActionResult<string>> Get()
        {
            Console.WriteLine("FilterController.Get()...");
            return "FilterController.Get()...";
        }

        //[SampleActionFilterAsync]
        [Route("Get2")]
        public async Task<ActionResult<string>> Get2()
        {
            Console.WriteLine("FilterController.Get2()...");
            return "FilterController.Get2()...";
        }

        [HttpPost]
        [ValidationFilter]
        public async Task<ActionResult<string>> PostPerson([FromBody] InvalidPerson person)
        {
            return person.Name;
        }

        [ServiceFilter(typeof(LoggingResponseHeaderFilterService))]
        [HttpGet]
        [Route("WithServiceFilter")]
        public IActionResult WithServiceFilter() => 
            Content($"- {nameof(FilterController)}.{nameof(WithServiceFilter)}");
    }
}
