using Roomy.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Roomy.Controllers
{
    public enum MessageType { SUCCESS, WARNING, ERROR, INFO }

    public class BaseController : Controller
    {
        protected RoomyDbContext db = new RoomyDbContext();

        protected void DisplayMessage(string message, MessageType type)
        {
            string[] types = { "success", "warning", "error", "info" };

            TempData["Message"] = message;
            TempData["MessageType"] = types[(int)type];
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

