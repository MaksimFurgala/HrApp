using System.ComponentModel.DataAnnotations;

namespace HrApp.Server.Data.Models
{
    public class Issue
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public Project Project { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }

        [Required]
        public DateTime UpdateDate { get; set; }

        [Required]
        public string Duration { get; set; }

        [Required]
        public string Type { get; set; }
    }
}
