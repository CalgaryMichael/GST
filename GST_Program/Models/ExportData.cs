using GST_Program.Domain.Models;
using GST_Program.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;

namespace GST_Program.Models {
	public class ExportData {
		public StringBuilder BuildData<T>() {
			StringBuilder str = new StringBuilder();
			
			MethodInfo mi = GetType().GetMethod(typeof(T).Name);
			var data = mi.Invoke(this, null);

			return str;
		}


		private List<Person> Person () {
			return new Database().ReadAllPerson();
		}


		private List<Badge> Badge() {
			return new Database().ReadAllBadge();
		}


		private List<BadgeHistory> BadgeHistory() {
			return new Database().ReadAllBadgeReceived();
		}
	}
}