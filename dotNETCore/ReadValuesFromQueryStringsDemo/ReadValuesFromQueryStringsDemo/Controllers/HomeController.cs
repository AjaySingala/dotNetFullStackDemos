using Microsoft.AspNetCore.Mvc;
using Microsoft.Docs.Samples;

namespace ReadValuesFromQueryStringsDemo.Controllers
{
    // MVC Controller. Not API.
    [Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        #region default conventional route {controller=Home}/{action=Index}/{id?} matches.

        ////[Route("")]
        ////[Route("Home")]
        ////[Route("Home/Index")]
        ////[Route("Home/Index/{id?}")]
        //public IActionResult Index(int? id)
        //{
        //    return ControllerContext.MyDisplayRouteInfo(id);
        //}

        ////[Route("Home/About")]
        ////[Route("Home/About/{id?}")]
        //public IActionResult About(int? id)
        //{
        //    return ControllerContext.MyDisplayRouteInfo(id);
        //}

        #endregion

        #region token replacement for action and controller.

        //[Route("")]
        //[Route("Home")]
        //[Route("[controller]/[action]")]
        //public IActionResult Index()
        //{
        //    return ControllerContext.MyDisplayRouteInfo();
        //}

        //[Route("[controller]/[action]")]
        //public IActionResult About()
        //{
        //    return ControllerContext.MyDisplayRouteInfo();
        //}

        #endregion
    }
}
