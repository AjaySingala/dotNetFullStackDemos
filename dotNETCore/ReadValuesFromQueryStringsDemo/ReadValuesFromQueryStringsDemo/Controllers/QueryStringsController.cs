using Microsoft.AspNetCore.Mvc;
using Microsoft.Docs.Samples;

namespace ReadValuesFromQueryStringsDemo.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class QueryStringsController : Controller
    {
        // Read Scalar Values.
        //[HttpGet]       // api/QueryStrings.    Requires [ApiController] and [Route] at the top.
        //[HttpGet("/v1")]  // /v1.
        //[HttpGet(template: "v1")]       // api/QueryStrings/v1.
        [HttpGet(template: "/v1", Name = "GetQueryStringsAsScalarValues")]  // /v1.
        public IActionResult GetFullNameFromScalarValues(
            [FromQuery] string firstName,
            [FromQuery] string lastName)
        {
            //return ControllerContext.MyDisplayRouteInfo(firstName, lastName);
            return Ok(new { FullName = $"{firstName} {lastName}" });
        }

        //Read Array Values.
        [HttpGet(template: "/v2", Name = "GetMultipleQueryStringsAsArray")]     // /v2.
        public IActionResult GetProductsByIds([FromQuery] int[] ids)
        {
            return Ok(new { ProductIds = ids });
        }

        // Read Object Values.
        [HttpGet("/v3", Name = "GetMultipleQueryStringsAsObject")]
        public IActionResult GetFullNameFromObject([FromQuery] Person queryStringParameters)
        {
            return Ok(new { FullName = $"{queryStringParameters.FirstName} {queryStringParameters.LastName}" });
        }
        public record Person(string FirstName, string LastName);

        [HttpGet("api/try/test")]       // api/try/test?id=123
        //[HttpGet("test/{id?}")]           // api/QueryStrings/test/123'  // Requires[ApiController] and[Route] at the top.
        public IActionResult Test(int? id)
        {
            //IActionResult result = Ok(new { id = id, name = "John" });
            var result = Ok(new { customerid = id });
            return result;
        }

        // Two actions with the same name, but different Route "templates".
        [HttpGet(template: "ById")]
        public IActionResult GetBy(int id)
        {
            return ControllerContext.MyDisplayRouteInfo(id);
        }

        [HttpGet(template: "ByExternalId")]
        public IActionResult GetBy(Guid id)
        {
            return ControllerContext.MyDisplayRouteInfo(id.ToString());
        }
    }
}
