using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GST_Program.Domain.ViewModels {
	public class BadgeReceivedList {
		public List<BadgeReceived> badges { get; set; }
		public String ID { get; set; }
		public int count { get; set; }
	}
}
