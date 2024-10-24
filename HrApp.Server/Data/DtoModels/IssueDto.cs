using HrApp.Server.Data.Models;

namespace HrApp.Server.Data.DtoModels
{
    public class IssueDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ProjectDto Project { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string Duration { get; set; }
        public string Type { get; set; }
    }
}
