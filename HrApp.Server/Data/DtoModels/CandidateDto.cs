using System.ComponentModel.DataAnnotations;

namespace HrApp.Server.Data.DtoModels
{
    public class CandidateDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string? Avatar { get; set; }

        public string? Contacts { get; set; }

        public int? Age { get; set; }

        public string? Education { get; set; }

        public string? Description { get; set; }

        public string? AdditionalInfo { get; set; }

        public string Position { get; set; }
    }
}
