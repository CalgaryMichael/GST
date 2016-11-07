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
			return View();
        }


		// GET: Admin/PersonType
		public ActionResult PersonType(string type) {
			DatabaseModel file = new DatabaseModel();
			PersonViewModel pvm = new PersonViewModel();
			pvm.people = file.ReadAllPersonByType(type);
			pvm.count = pvm.people.Count;

			return View("PersonSearch", pvm);
		}


		// GET: Admin/BadgeBank
		public ActionResult BadgeBank() {
			DatabaseModel file = new DatabaseModel();
			BadgeBank bb = new BadgeBank();
			bb.badges = file.ReadAllBadge();
			bb.count = bb.badges.Count;

			return View(bb);
		}


		// GET: Admin/BadgeBankType
		public ActionResult BadgeBankType(string type) {
			DatabaseModel file = new DatabaseModel();
			BadgeBank bb = new BadgeBank();

			if (type == "All") {
				bb.badges = file.ReadAllBadge();
				bb.count = bb.badges.Count;
			} else {
				bb.badges = file.ReadAllBadgeByType(type);
				bb.count = bb.badges.Count;
			}

			return View("BadgeBankSearch", bb);
		}


		// GET: Admin/BadgeCreate
		public ActionResult BadgeCreate() {
			return View();
		}


		// POST: Admin/BadgeCreate
		[HttpPost]
		public ActionResult BadgeCreate(Badge b) {
			DatabaseModel file = new DatabaseModel();
			b.Date_Activated_Str = b.Date_Activated.ToString("yyyy-MM-dd HH:mm:ss.fff");

			if (ModelState.IsValid) {
				file.Create(b);
				return RedirectToAction("BadgeBank");
			}

			// Return same Badge if invalid field(s)
			return View(b);
		}


		// GET: Admin/BadgeDetail
		public ActionResult BadgeDetail(string id) {
			DatabaseModel file = new DatabaseModel();
			Badge b = new Badge();
			b = file.ReadSingleBadge(id);

			return View(b);
		}


		// GET: Admin/BadgeEdit
		[HttpGet]
		public ActionResult BadgeEdit(string id) {
			DatabaseModel file = new DatabaseModel();
			Badge b = new Badge();
			b = file.ReadSingleBadge(id);

			return View(b);
		}


		// POST: Admin/BadgeEdit
		[HttpPost]
		public ActionResult BadgeEdit(Badge b) {
			DatabaseModel file = new DatabaseModel();

			if (ModelState.IsValid) {
				file.Update(b);
				return RedirectToAction("BadgeBank");
			}

			return View(b);
		}


		// GET: /Admin/BadgeDelete
		public ActionResult BadgeDelete(string id) {
			DatabaseModel file = new DatabaseModel();
			Badge b = file.ReadSingleBadge(id);

			return View(b);
		}


		// POST: /Admin/BadgeDelete
		[HttpPost]
		public ActionResult BadgeDelete(Badge b) {
			DatabaseModel file = new DatabaseModel();
			file.Delete(b);
			return RedirectToAction("BadgeBank");
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