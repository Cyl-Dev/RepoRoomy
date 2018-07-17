using Roomy.Models;
using Roomy.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace Roomy.Controllers
{
    public class UsersController : Controller
    {
        private RoomyDbContext db = new RoomyDbContext();

        // GET: Users
        [HttpGet]
        public ActionResult Create()
        {

            ViewBag.Civilities = db.Civilities.ToList();


            /*
            List<Civility> numQuery2 = db.Civilities.ToList();

            ViewBag.CivilityList = numQuery2;
            //            ViewBag.CivilityList = new SelectList(Enum.GetValues(typeof(Civility)));
            */

            /*

            IEnumerable<SelectListItem> items = db.Civilities.Select(c => new SelectListItem
            {
                Value = c.ID.ToString(),
                Text = c.Label
            });
            ViewBag.CivilityList = items;

    */




            return View();
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                // enregister
                db.Users.Add(user);
                db.SaveChanges();

            }

            ViewBag.Civilities = db.Civilities.ToList();
            return View();
        }

    }
}