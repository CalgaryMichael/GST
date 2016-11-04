using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GST_Program.Domain {
	public class BadgeReceived {
		public int Transaction_Number { get; set; }
		public string Badge_ID { get; set; }
		public string ID_Giver { get; set; }
		public string Student_ID { get; set; }
		public DateTime Time_Stamp { get; set; }
		public string Comment { get; set; }

		public Badge badge { get; set; }
		public Person giver { get; set; }
		public Person receiver { get; set; }
	}
}
