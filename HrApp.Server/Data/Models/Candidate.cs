using System.ComponentModel.DataAnnotations;

namespace HrApp.Server.Data.Models
{
    public class Candidate
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string? Avatar { get; set; }

        public string? Contacts { get; set; }

        public int? Age { get; set; }

        public string? Education { get; set; }

        public string? Description { get; set; }

        public string? AdditionalInfo { get; set; }

        [Required]
        public string Position { get; set; }
    }
}
