using Roomy.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Roomy.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            // MessageManager.DisplayErrorMessage(TempData, "Test du système !!!!");
            // this.DisplaySuccessMessage("Test du système 2!!!!");
            return View();
        }

        public ActionResult About()
        {
            return View();
        }



    }
}