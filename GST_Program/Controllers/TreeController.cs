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

		#region Give Badge

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
		public ActionResult GiveBadge(FormCollection form) {
			var service = new Database();
			BadgeHistory b = new BadgeHistory();

			var badge = form["badge"];
			var giver = form["giver"];
			var receiver = form["receiver"];
			var comment = form["Comment"];

			// Test to see if Form Input for Badge is a Name or a Number
			if (!TestString.IsAllDigits(badge)) {
				b.Badge = service.ReadSingleBadgeByName(badge);
				b.Badge_ID = Convert.ToString(b.Badge.Badge_ID);
			}

			// Test to see if Form Input for Giver is a Name or a Number
			if (!TestString.IsAllDigits(giver)) {
				b.Giver = service.ReadSinglePersonByName(giver);
				b.Giver_ID = Convert.ToString(b.Giver.Person_ID);
			}

			// Test to see if Form Input for Receiver is a Name or a Number
			if (!TestString.IsAllDigits(receiver)) {
				b.Receiver = service.ReadSinglePersonByName(receiver);
				b.Student_ID = Convert.ToString(b.Receiver.Person_ID);
			}

			b.Time_Stamp = DateTime.Now;
			b.Comment = comment;

			if (ModelState.IsValid) {
				service.Create(b);
				return RedirectToAction("Grid");
			}

			return View(b);
		}

		#endregion
	}
}