using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GST_Program.Domain {
	public class Badge {
		[Required(ErrorMessage = "Please enter valid Badge")]
		public string Badge_ID { get; set; }					// BadgeBank.Badge_ID

		[Required(ErrorMessage = "Please enter valid Name")]
		public string Badge_Name { get; set; }					// BadgeBank.Badge_Name

		[Required(ErrorMessage = "Please enter valid Summary")]
		public string Badge_Summary { get; set; }				// BadgeBank.Badge_Summary
		public string Badge_Category { get; set; }				// BadgeBank.Badge_Category

		[Required(ErrorMessage = "Please enter valid Give Type")]
		public string Badge_Give_Type { get; set; }				// BadgeBank.Badge_Give_Type
		public DateTime Date_Activated { get; set; }			// BadgeBank.Date_Activated
		public string Date_Activated_Str { get; set; }
		public string Date_Retired { get; set; }				// BadgeBank.DateRetired
		public string Notes { get; set; }						// BadgeBank.Notes

		[Required(ErrorMessage = "Please enter valid Image Address")]
		public string Image_Address { get; set; }				// BadgeBank.Image_Address
	}
}
