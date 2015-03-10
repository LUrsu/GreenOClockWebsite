using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GreenOClock.Mvc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Green O'Clock";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
