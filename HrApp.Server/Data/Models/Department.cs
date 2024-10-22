using System.ComponentModel.DataAnnotations;

namespace HrApp.Server.Data.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DepartmentStatus DepartmentStatus { get; set; }

        public Company Company { get; set; }

    }

    public enum DepartmentStatus
    {
        Open, Closed
    }
}
