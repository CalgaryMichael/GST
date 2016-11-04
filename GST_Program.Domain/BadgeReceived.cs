using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GST_Program.Domain {
	public class BadgeReceived {
		public string transactionNumber { get; set; }
		public Badge badge { get; set; }
		public string receiverID { get; set; }
		public string giverID { get; set; }
		public DateTime timeStamp { get; set; }
		public string comment { get; set; }
	}
}
