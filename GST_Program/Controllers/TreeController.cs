using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GST_Program.Domain;
using GST_Program.Domain.ViewModels;
using GST_Program.Models;

namespace GST_Program.Controllers {
    public class TreeController : Controller {
        
		// GET: Tree
        public ActionResult Index() {
            return View();
        }


		// GET: Tree/GridView
		public ActionResult GridView(String ID) {
			// ID: used to get Badges received by Person with ID
			return View();
		}


		// GET: Tree/GiveBadge
		public ActionResult GiveBadge() {
			DatabaseModel file = new DatabaseModel();
			BadgeBank bb = new BadgeBank();
			bb.badges = file.ReadAllBadge();

			return View(bb);
		}
    }
}