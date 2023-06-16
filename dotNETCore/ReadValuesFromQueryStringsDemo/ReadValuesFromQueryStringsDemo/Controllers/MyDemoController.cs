using Microsoft.AspNetCore.Mvc;
using Microsoft.Docs.Samples;

namespace ReadValuesFromQueryStringsDemo.Controllers
{
    public class MyDemoController : Controller
    {
        //[Route("")]
        //[Route("Home")]
        //[Route("Home/Index")]
        //[Route("Home/Index/{id?}")]
        public IActionResult MyIndex(int? id)
        {
            return ControllerContext.MyDisplayRouteInfo(id);
        }

        //[Route("Home/About")]
        //[Route("Home/About/{id?}")]
        public IActionResult MyAbout(int? id)
        {
            return ControllerContext.MyDisplayRouteInfo(id);
        }

    }
}
