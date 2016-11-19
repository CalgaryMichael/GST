using System.Collections.Generic;
using System.Web.Mvc;
using GST_Program.Domain.Models;
using GST_Program.Domain.Services;

namespace GST_Program.Controllers {
	public class AdminController : Controller {

		#region People

		// GET: Admin
		public ActionResult Index() {
			return View();
		}

		// GET: Admin/PersonType
		public ActionResult PersonType(string type) {
			var service = new Database();
			var pvm = service.ReadAllPersonByType(type);
			return View("PersonSearch", pvm);
		}

		// GET: Admin/PersonDetail
		public ActionResult PersonDetail(string id) {
			var service = new Database();
			var result = service.ReadSinglePerson(id);
			return View(result);
		}

		// GET: Admin/PersonEdit
		public ActionResult PersonEdit(string id) {
			var service = new Database();
			var result = service.ReadSinglePerson(id);
			return View(result);
		}

		// POST: Admin/PersonEdit
		[HttpPost]
		public ActionResult PersonEdit(Person p) {
			if (ModelState.IsValid) {
				var service = new Database();
				service.Update(p);
				return RedirectToAction("Index");
			}

			return View(p);
		}

		// GET: Admin/PersonDelete
		public ActionResult PersonDelete(string id) {
			var service = new Database();
			var result = service.ReadSinglePerson(id);
			return View(result);
		}

		// POST: Admin/PersonDelete
		[HttpPost]
		public ActionResult PersonDelete(Person p) {
			var service = new Database();
			service.Delete(p);
			return RedirectToAction("Index");
		}

		#endregion

		#region BadgeBank

		// GET: Admin/BadgeBank
		public ActionResult BadgeBank() {
			var service = new Database();
			var b = service.ReadAllBadge();
			return View(b);
		}

		// GET: Admin/BadgeBankType
		public ActionResult BadgeBankType(string type) {
			var service = new Database();
			List<Badge> bb;

			if (type == "All")
				bb = service.ReadAllBadge();
			else
				bb = service.ReadAllBadgeByType(type);

			return View("BadgeBankSearch", bb);
		}

		// GET: Admin/BadgeCreate
		public ActionResult BadgeCreate() {
			return View();
		}

		// POST: Admin/BadgeCreate
		[HttpPost]
		public ActionResult BadgeCreate(Badge b) {
			var service = new Database();

			if (ModelState.IsValid) {
				service.Create(b);
				return RedirectToAction("BadgeBank");
			}

			// Return same Badge if invalid field(s)
			return View(b);
		}

		// GET: Admin/BadgeDetail
		public ActionResult BadgeDetail(string id) {
			var service = new Database();
			var b = service.ReadSingleBadge(id);
			return View(b);
		}

		// GET: Admin/BadgeEdit
		[HttpGet]
		public ActionResult BadgeEdit(string id) {
			var service = new Database();
			var b = service.ReadSingleBadge(id);
			return View(b);
		}

		// POST: Admin/BadgeEdit
		[HttpPost]
		public ActionResult BadgeEdit(Badge b) {
			if (ModelState.IsValid) {
				var service = new Database();
				service.Update(b);
				return RedirectToAction("BadgeBank");
			}

			return View(b);
		}

		// GET: /Admin/BadgeDelete
		public ActionResult BadgeDelete(string id) {
			var service = new Database();
			var b = service.ReadSingleBadge(id);
			return View(b);
		}

		// POST: /Admin/BadgeDelete
		[HttpPost]
		public ActionResult BadgeDelete(Badge b) {
			var service = new Database();
			service.Delete(b);
			return RedirectToAction("BadgeBank");
		}

		#endregion

		#region BadgeHistory

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
		public ActionResult BadgeHistoryGiver(string id) {
			var service = new Database();
			List<BadgeHistory> b = service.ReadAllBadgeReceivedByGiver(id);
			return View("BadgeHistorySearch", b);
		}

		// POST: Admin/BadgeHistoryReceiver
		[HttpPost]
		public ActionResult BadgeHistoryReceiver(string id) {
			var service = new Database();
			List<BadgeHistory> result = service.ReadAllBadgeReceivedByReceiver(id);
			return View("BadgeHistorySearch", result);
		}

		// POST: Admin/BadgeHistoryBadge
		[HttpPost]
		public ActionResult BadgeHistoryBadge(string id) {
			var service = new Database();
			List<BadgeHistory> result = service.ReadAllBadgeReceivedByBadge(id);
			return View("BadgeHistorySearch", result);
		}

		#endregion
	}
}