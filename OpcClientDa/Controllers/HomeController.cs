using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace OpcClientDa.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
