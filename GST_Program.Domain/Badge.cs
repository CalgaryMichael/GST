using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GST_Program.Domain {
	public class Badge {
		public string Badge_ID { get; set; }			// BadgeBank.Badge_ID
		public string Badge_Name { get; set; }			// BadgeBank.Badge_Name
		public string Badge_Summary { get; set; }		// BadgeBank.Badge_Summary
		public string Badge_Category { get; set; }		// BadgeBank.Badge_Category
		public string Badge_Give_Type { get; set; }		// BadgeBank.Badge_Give_Type
		public string Date_Activated { get; set; }		// BadgeBank.Date_Activated
		public string Date_Retired { get; set; }		// BadgeBank.DateRetired
		public string Badge_Notes { get; set; }			// BadgeBank.Notes
		public string Image_Address { get; set; }		// BadgeBank.Image_Address
	}
}
