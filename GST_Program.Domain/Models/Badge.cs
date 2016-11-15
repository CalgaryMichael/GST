using System;
using System.ComponentModel.DataAnnotations;

namespace GST_Program.Domain.Models
{
    public class Badge
    {
        [Required(ErrorMessage = "Please enter valid Badge")]
        public int BadgeId { get; set; }

        [Required(ErrorMessage = "Please enter valid Name")]
        public string BadgeName { get; set; }

        [Required(ErrorMessage = "Please enter valid Summary")]
        public string BadgeSummary { get; set; }
        public string BadgeCategory { get; set; }

        [Required(ErrorMessage = "Please enter valid Give Type")]
        public string BadgeGiveType { get; set; }
        public DateTime DateActivated { get; set; }
        public DateTime DateRetired { get; set; }
        public string Notes { get; set; }

        [Required(ErrorMessage = "Please enter valid Image Address")]
        public string ImageAddress { get; set; }
    }
}