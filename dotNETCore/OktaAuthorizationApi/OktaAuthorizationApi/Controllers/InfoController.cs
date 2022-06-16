using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace OktaAuthorizationApi.Controllers
{
    [EnableCors("AllowAll")]    // Enables CORS for this route.
    [ApiController]
    [Route("api")]
    public class InfoController : ControllerBase
    {
        // GET: api/whoami
        [Authorize]
        [HttpGet]
        [Route("whoami")]
        public Dictionary<string, string> GetAuthorized()
        {
            var principal = HttpContext.User.Identity as ClaimsIdentity;
            return principal.Claims
               .GroupBy(claim => claim.Type)
               .ToDictionary(claim => claim.Key, claim => claim.First().Value);
        }

        // GET: api/hello
        [AllowAnonymous]
        [HttpGet]
        [Route("hello")]
        public string GetAnonymous()
        {
            return "You are anonymous";
        }
    }
}
