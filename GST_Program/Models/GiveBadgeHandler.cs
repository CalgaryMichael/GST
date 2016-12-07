using System;
using System.Collections.Generic;
using System.Linq;
using GST_Program.Domain.Services;
using GST_Program.Domain.Models;
using System.Web.Mvc;

namespace GST_Program.Models {
	public class GiveBadgeHandler {
		private Database service { get; set; }

		public GiveBadgeHandler() {
			service = new Database();
		}

		public void GiveBadge(Badge core, string studentID) {
			var b = new BadgeHistory();
			b.Badge = core;
			b.Giver_ID = "10014";
			b.Giver = service.ReadSinglePerson("10014");
			b.Student_ID = studentID;
			b.Receiver = service.ReadSinglePerson(studentID);
			b.Time_Stamp = DateTime.Now;

			b.Pos_X = 0;
			b.Pos_Y = 0;

			// Save BadgeHistory to db
			service.Create(b);
		}


		public void GiveBadge(FormCollection form) {
			var b = new BadgeHistory();

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

			// Save BadgeHistory to db
			service.Create(b);
		}


		private void CheckCoreStatus(string studentID) {
			var cores = service.ReadAllCores();
			var badges = GetCompetencyBadgesFromBadgeHistory(studentID);

			foreach (var c in cores) {
				if (!c.CompetencyBadge.Except(badges).Any()) { 
					GiveBadge(c.CoreBadge, studentID);
				}
			}
		}


		private List<Badge> GetCompetencyBadgesFromBadgeHistory(string ID) {
			var bh = service.ReadAllBadgeReceivedByReceiver(ID);

			List<Badge> badges = new List<Badge>();
			foreach(var b in bh) {
				if (b.Badge.Badge_Category == "Competency")
					badges.Add(b.Badge);
			}

			return badges;
		}
	}
}