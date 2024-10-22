using System.ComponentModel.DataAnnotations;

namespace HrApp.Server.Data.DtoModels
{
    public class UserAccountDto
    {
        public string Login { get; set; }

        public string Password { get; set; }
    }
}
