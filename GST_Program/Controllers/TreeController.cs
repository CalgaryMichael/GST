using System;
using System.Collections.Generic;
using System.Web.Mvc;
using GST_Program.Domain.Models;
using GST_Program.Domain.Services;
using GST_Program.Models;

namespace GST_Program.Controllers {
	public class TreeController : Controller {
		private List<BadgeHistory> _badgeList = new List<BadgeHistory>();

		// GET: Tree
		public ActionResult Index() {
			return View();
		}


		// GET: Tree/Grid
		public ActionResult Grid(string id) {
			var service = new Database();
			_badgeList = service.ReadAllBadgeReceivedByReceiver("10010");
			return View(_badgeList);
		}


		// GET: Tree/GiveBadge
		public ActionResult GiveBadge() {
			var service = new Database();
			var bb = service.ReadAllBadge();

			var pvm = service.ReadAllPerson();

			ViewBag.Badges = bb;
			ViewBag.People = pvm;

			return View();
		}


		// POST: Tree/GiveBadge
		[HttpPost]
		public ActionResult GiveBadge(BadgeHistory b) {
			var service = new Database();

			b.Time_Stamp = DateTime.Now;

			var badge = service.ReadSingleBadge(b.Badge_ID);
			var giver = service.ReadSinglePerson(b.Giver_ID);

			if (ModelState.IsValid) {
				service.Create(b);
				return RedirectToAction("GridView");
			}

			return View(b);
		}
	}
}