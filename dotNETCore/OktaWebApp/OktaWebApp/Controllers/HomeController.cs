using Microsoft.AspNetCore.Mvc;
using OktaWebApp.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;

namespace OktaWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Authorize]
        public IActionResult Profile()
        {
            return View(HttpContext.User.Claims);
        }

        [Authorize]
        public IActionResult Protected()
        {
            // Only for signed-in users!
            return View("Profile", HttpContext.User.Claims);
        }

        [AllowAnonymous]
        public IActionResult PublicAccess()
        {
            // For all users, even anonymous ones!
            return View();
        }
    }
}