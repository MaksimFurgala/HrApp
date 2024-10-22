using System.ComponentModel.DataAnnotations;

namespace HrApp.Server.Data.Models
{
    public class UserAccount
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
