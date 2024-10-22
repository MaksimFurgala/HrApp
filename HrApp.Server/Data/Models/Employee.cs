using System.ComponentModel.DataAnnotations;

namespace HrApp.Server.Data.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Age { get; set; }

        public string Avatar { get; set; }

        public DateTime CreateDate { get; set; }

        [Required]
        public EmployeeGender Gender { get; set; }

        [Required]
        public UserAccount Account { get; set; }
    }

    public enum EmployeeGender
    {
        MALE, FEMALE
    }
}
