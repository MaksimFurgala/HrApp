using System.ComponentModel.DataAnnotations;

namespace HrApp.Server.Data.Models
{
    public class Company
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string? Logo { get; set; }
    }
}
