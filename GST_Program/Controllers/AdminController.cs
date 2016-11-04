using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GST_Program.Domain;

namespace GST_Program.Controllers {
    public class AdminController : Controller {

        // GET: Admin
        public ActionResult Index() {
            return View();
        }


		// GET: Admin/BadgeBank
		public ActionResult BadgeBank() {
			return View();
		}


		// GET: Admin/BadgeHistory
		public ActionResult BadgeHistory(String ID) {
			// ID: used to get Badges received by Person with ID
			return View();
		}
    }
}