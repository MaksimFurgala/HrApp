using System.ComponentModel.DataAnnotations;

namespace HrApp.Server.Data.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
