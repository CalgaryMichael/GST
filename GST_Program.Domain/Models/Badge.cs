using System;
using System.ComponentModel.DataAnnotations;

namespace GST_Program.Domain.Models {
	public class Badge {
		[Required(ErrorMessage = "Please enter valid Badge")]
		public int Badge_ID { get; set; }

		[Required(ErrorMessage = "Please enter valid Name")]
		public string Badge_Name { get; set; }

		[Required(ErrorMessage = "Please enter valid Summary")]
		public string Badge_Summary { get; set; }
		public string Badge_Category { get; set; }

		[Required(ErrorMessage = "Please enter valid Give Type")]
		public string Badge_Give_Type { get; set; }
		public DateTime Date_Activated { get; set; }
		public DateTime Date_Retired { get; set; }
		public string Notes { get; set; }

		[Required(ErrorMessage = "Please enter valid Image Address")]
		public string Image_Address { get; set; }
	}
}