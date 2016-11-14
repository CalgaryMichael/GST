using System;

namespace GST_Program.Domain.Models
{
    public class BadgeHistory
    {
        public int TransactionNum { get; set; }
        public string BadgeId { get; set; }
        public string GiverId { get; set; }
        public string StudentId { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Comment { get; set; }

        public Badge Badge { get; set; }
        public Person Giver { get; set; }
        public Person Receiver { get; set; }
    }
}