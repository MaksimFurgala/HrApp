using HrApp.Server.Domain.Models;

namespace HrApp.Server.Interfaces
{
    public interface IDashboardService
    {
        public Task<Dashboard> GetDashboardData();
    }
}
