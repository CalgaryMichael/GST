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

			return RedirectToAction("Index", "Admin");
		}
	}
}