namespace HrApp.Server.Domain.Models
{
    public class Dashboard
    {
        public SimpleStatistic EmployeesStatistic { get; set; }
        public SimpleStatistic JobView { get; set; }
        public SimpleStatistic JobApplied { get; set; }
        public GenderStatistic GenderStatistic { get; set; }
    }
}
