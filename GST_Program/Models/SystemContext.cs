using System.Configuration;

namespace GST_Program.Models {
	public static class SystemContext {
		static SystemContext() {
			MasterConnectionString = ConfigurationManager.ConnectionStrings["MasterConnection"].ConnectionString;
			GstConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
		}

		public static string MasterConnectionString { get; }
		public static string GstConnectionString { get; }
	}
}