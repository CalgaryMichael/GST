using System;
using System.Collections.Generic;
using System.Web.Mvc;
using GST_Program.Domain.Models;
using GST_Program.Domain.Services;
using GST_Program.Models;

namespace GST_Program.Controllers
{
    public class TreeController : Controller
    {
        private List<BadgeHistory> _badgeList = new List<BadgeHistory>();

        // GET: Tree
        public ActionResult Index()
        {
            return View();
        }


        // GET: Tree/GridView
        public ActionResult GridView(string id)
        {
            var service = new GstService(SystemContext.GstConnectionString);

            _badgeList = service.ReadAllBadgeReceivedByReceiver("10010");

            // ID: used to get Badges received by Person with ID
            return View(_badgeList);
        }


        // GET: Tree/GiveBadge
        public ActionResult GiveBadge()
        {
            var service = new GstService(SystemContext.GstConnectionString);

            var bb = new BadgeBank {Badges = service.ReadAllBadge()};

            var pvm = service.ReadAllPerson();

            ViewBag.Badges = bb;
            ViewBag.People = pvm;

            return View();
        }


        // POST: Tree/GiveBadge
        [HttpPost]
        public ActionResult GiveBadge(BadgeHistory b)
        {
            var service = new GstService(SystemContext.GstConnectionString);

            b.TimeStamp = DateTime.Now;

            var badge = service.ReadSingleBadge(b.BadgeId);
            var giver = service.ReadSinglePerson(b.GiverId);

            if (ModelState.IsValid)
            {
                service.Create(b);
                return RedirectToAction("GridView");
            }

            return View(b);
        }
    }
}