using GST_Program.Domain.Models;
using GST_Program.Domain.Services;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace GST_Program.Models {
	public class ExportData {
		public StringBuilder BuildData<T>() where T : new() {
			T instance = new T();
			var mi = GetType().GetMethod($"_{typeof(T).Name}").Invoke(this, null);
			var data = (StringBuilder)mi;

			return data;
		}


		public StringBuilder _Person() {
			var csv = new StringBuilder();
			List<Person> persons = new Database().ReadAllPerson();

			foreach(Person p in persons) {
				var newline = $"\"{p.Person_ID}\",\"{p.Person_Name}\",\"{p.Person_Email}\",\"{p.Person_Type}\",\"{p.Admin_Status}\"";
				csv.AppendLine(newline);
			}

			return csv;
		}


		public StringBuilder _Badge() {
			var csv = new StringBuilder();
			List<Badge> badges = new Database().ReadAllBadge();

			foreach (Badge b in badges) {
				var newline = $"\"{b.Badge_ID}\",\"{b.Badge_Name}\",\"{b.Badge_Category}\",\"{b.Badge_Give_Type}\",\"{b.Badge_Summary}\",\"{b.Date_Activated}\",\"{b.Date_Retired}\",\"{b.Image_Address}\"";
				csv.AppendLine(newline);
			}

			return csv;
		}


		public StringBuilder _BadgeHistory() {
			var csv = new StringBuilder();
			List<BadgeHistory> badges = new Database().ReadAllBadgeReceived();

			foreach (BadgeHistory b in badges) {
				var newline = $"\"{b.Transaction_Num}\",\"{b.Badge_ID}\",\"{b.Badge.Badge_Name}\",\"{b.Giver_ID}\",\"{b.Giver.Person_Name}\",\"{b.Student_ID}\",\"{b.Receiver.Person_Name}\",\"{b.Time_Stamp}\",\"{b.Comment}\"";
				csv.AppendLine(newline);
			}

			return csv;
		}
	}
}