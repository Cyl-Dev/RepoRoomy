using Roomy.Areas.BackOffice.Models;
using Roomy.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Roomy.Utils;


namespace Roomy.Areas.BackOffice.Controllers
{
    public class AuthenticationController : Controller
    {
        private RoomyDbContext db = new RoomyDbContext();

        // GET: BackOffice/Authentication/Login
        public ActionResult Login()
        {

            return View();
        }


        // POST: BackOffice/Authentication/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(AuthenticationLoginViewModel model)
        {
            var passwordHash = model.Password.HashMD5();
            var user = db.Users.SingleOrDefault(x => x.Mail == model.Login && x.Password == passwordHash);
            if (user == null)
            {
                //TempData["message"] = "Votre login n'est pas bon !";


                //1) ModelState.AddModelError("", "Utilisateur ou mot de passe incorrect");

                ViewBag.ErrorMessage = "Utilisateur ou mot de passe incorrect";


                return View(model);
            }

            Session.Add("USER_BO", user);

            return RedirectToAction("Index", "Dashboard", new { area = "BackOffice" });
        }


        // GET: BackOffice/Authentication/Logout
        public ActionResult Logout()
        {
            Session.Clear();

            return RedirectToAction("Index", "Home", new { area = "" });
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}