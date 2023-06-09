using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCRoutingDemo.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Process
        public string List()
        {
            return "Here is a list of Customers...";
        }
    }
}