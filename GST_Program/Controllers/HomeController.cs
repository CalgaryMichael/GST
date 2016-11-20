using System.Web.Mvc;
using GST_Program.Domain.Services;
using GST_Program.Models;
using System;

namespace GST_Program.Controllers {
	public class HomeController : Controller {
		// GET: Home
		public ActionResult Index() {
			var service = new Database();

            service.CreateDatabase();
            service.CreateTables();
            service.InsertData();

            //return RedirectToAction("Index", "Admin");
            return View();
		}
        public ActionResult Login(string e)
        {
            var service = new Database();
            var admin = service.GetPersonByEmail(e).Admin_Status;
            if(admin)
                return Json(Url.Action("Index", "Admin"));
            else if (!admin)
                return Json(Url.Action("Index", "Tree"));
            return Json(Url.Action("Index", "Home"));
        }
	}
}