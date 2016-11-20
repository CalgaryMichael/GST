using System.Linq;

namespace GST_Program.Models {
	public static class TestString {
		public static bool IsAllDigits(string s) {
			return s.All(char.IsDigit);
		}
	}
}