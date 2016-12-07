using System;

namespace GST_Program.Domain.Models {
    public class BadgeHistory {
        public int Transaction_Num { get; set; }
        public string Badge_ID { get; set; }
        public string Giver_ID { get; set; }
        public string Student_ID { get; set; }
        public DateTime Time_Stamp { get; set; }
        public string Comment { get; set; }
        public int Pos_X { get; set; }
        public int Pos_Y { get; set; }

        public Badge Badge { get; set; }
        public Person Giver { get; set; }
        public Person Receiver { get; set; }
    }
}