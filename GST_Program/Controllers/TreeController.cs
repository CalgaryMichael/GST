using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GST_Program.Domain;
using GST_Program.Models;

namespace GST_Program.Controllers {
    public class TreeController : Controller {

        DatabaseModel database = new DatabaseModel();
        List<BadgeReceived> badgeList = new List<BadgeReceived>();

		// GET: Tree
        public ActionResult Index() {
            return View();
        }


		// GET: Tree/GridView
		public ActionResult GridView(String ID) {
            badgeList = database.ReadAllBadgeReceivedByReceiver("10010");

			// ID: used to get Badges received by Person with ID
			return View(badgeList);
		}


		// GET: Tree/GiveBadge
		public ActionResult GiveBadge() {
			return View();
		}
    }
}