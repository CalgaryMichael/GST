using System;
using System.Collections.Generic;
using System.Web.Mvc;
using GST_Program.Domain.Models;
using GST_Program.Domain.Services;
using GST_Program.Models;

namespace GST_Program.Controllers {
	public class TreeController : Controller {

		// GET: Tree
		public ActionResult Index(string id) {
			var service = new Database();
			List<BadgeHistory> b = service.ReadAllBadgeReceivedByReceiver(id);
			return View(b);
		}


		// GET: Tree/Grid
		public ActionResult Grid(string id) {
			var service = new Database();
			var person = service.ReadSinglePerson(id);
			ViewBag.Person = person;

			List<Core> core = service.ReadAllCores();
			ViewBag.Core = core;

			var badgeHistoryList = service.ReadAllBadgeReceivedByReceiver(id);

			return View(badgeHistoryList);
		}


		// GET: Tree/BadgeHistoryDetail
		public ActionResult BadgeHistoryDetail(string id) {
			var service = new Database();
			var b = service.ReadSingleBadgeReceived(id);
			return View(b);
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
			
			var receiver = form["receiver"];
			var comment = form["Comment"];
			
			// Find Badge
			b.Badge = service.ReadSingleBadge(form["badge"]);
			b.Badge_ID = b.Badge.Badge_ID;
			
			// Find Person logged in
			b.Giver = service.ReadSinglePersonByName(form["giver"]);
			b.Giver_ID = Convert.ToString(b.Giver.Person_ID);

			// Test to see if Form Input for Receiver is a Name or a Number
			if (!TestString.IsAllDigits(receiver)) {
				b.Receiver = service.ReadSinglePersonByName(receiver);
				b.Student_ID = Convert.ToString(b.Receiver.Person_ID);
			} else {
				b.Receiver = service.ReadSinglePerson(receiver);
				b.Student_ID = receiver;
			}

			b.Time_Stamp = DateTime.Now;
			b.Comment = comment;

			// Fill this in with the calculations for the X/Y assignment
			b.Pos_X = 0;
			b.Pos_Y = 0;

			if (ModelState.IsValid) {
				service.Create(b);
				return RedirectToAction($"Grid/{b.Student_ID}");
			}

			return View(b);
		}

		#endregion
	}
}