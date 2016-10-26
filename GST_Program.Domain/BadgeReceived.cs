using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GST_Program.Domain {
	class BadgeReceived {
		public String transactionNumber { get; set; }
		public Badge badge { get; set; }
		public String receiverID { get; set; }
		public String giverID { get; set; }
		public DateTime timeStamp { get; set; }
		public String comment { get; set; }
	}
}
