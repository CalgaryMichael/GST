using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GST_Program.Domain.Models {
	public class Core {
		public int Core_ID { get; set; }
		public int Competency_ID { get; set; }

		public Badge CoreBadge { get; set; }
		public List<Badge> CompetencyBadge { get; set; }
	}
}
