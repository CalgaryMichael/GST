using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GST_Program.Domain;
using GST_Program.Domain.ViewModels;
using GST_Program.Models;

namespace GST_Program.Controllers {
    public class AdminController : Controller {

        // GET: Admin
        public ActionResult Index() {
			DatabaseModel file = new DatabaseModel();
			PersonViewModel pvm = new PersonViewModel();
			pvm.people = file.ReadAllPerson();
			pvm.count = pvm.people.Count;

			return View(pvm);
        }


		// GET: Admin/BadgeBank
		public ActionResult BadgeBank() {
			DatabaseModel file = new DatabaseModel();
			BadgeBank brl = new BadgeBank();
			brl.badges = file.ReadAllBadge();
			brl.count = brl.badges.Count;

			return View(brl);
		}


		// Okay, so here is the lowdown on the BadgeHistory pages:
		// in a JQuery call, you will direct it to one of these
		// view calls depending on what the Admin is searching for
		// (i.e. if the Admin wants to see who has sent Badge x,
		// or what badges that Giver y has given, or what badges
		// Student z has received).

	
		// GET: Admin/BadgeHistory
		public ActionResult BadgeHistory() {
			return View();
		}
		
		// POST: Admin/BadgeHistoryGiver
		[HttpPost]
		public ActionResult BadgeHistoryGiver(string ID) {
			DatabaseModel file = new DatabaseModel();
			var result = new BadgeReceivedList();
			result.badges = file.ReadAllBadgeReceivedByGiver(ID);
			result.SearchTerm = ID;
			result.count = result.badges.Count;

			return View("BadgeHistorySearch", result);
		}


		// POST: Admin/BadgeHistoryReceiver
		[HttpPost]
		public ActionResult BadgeHistoryReceiver(string ID) {
			DatabaseModel file = new DatabaseModel();
			var result = new BadgeReceivedList();
			result.badges = file.ReadAllBadgeReceivedByReceiver(ID);
			result.count = result.badges.Count;

			return View("BadgeHistorySearch", result);
		}


		// POST: Admin/BadgeHistoryBadge
		[HttpPost]
		public ActionResult BadgeHistoryBadge(string ID) {
			DatabaseModel file = new DatabaseModel();
			var result = new BadgeReceivedList();
			result.badges = file.ReadAllBadgeReceivedByBadge(ID);
			result.count = result.badges.Count;

			return View("BadgeHistorySearch", result);
		}
	}
}