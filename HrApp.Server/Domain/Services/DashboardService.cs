using HrApp.Server.Data;
using HrApp.Server.Data.Models;
using HrApp.Server.Domain.Models;
using HrApp.Server.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HrApp.Server.Domain.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly AppDbContext _context;

        public DashboardService(AppDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Получаем данные для дашборда.
        /// </summary>
        /// <returns>данные для дашборда</returns>
        public async Task<Dashboard> GetDashboardData()
        {
            var currentMonth = DateTime.Now.Month;
            var employees = await _context.Employees.ToListAsync();
            var prevEmployees = employees.Count(e => e.CreateDate.Month == currentMonth - 1);
            var currentEmployees = employees.Count(e => e.CreateDate.Month == currentMonth);
            bool diffIsAsc = currentEmployees > prevEmployees;
            int total = diffIsAsc ?
                (currentEmployees / prevEmployees * 100) - 100 :
                (prevEmployees / currentEmployees * 100) - 100;

            return new Dashboard()
            {
                EmployeesStatistic = new SimpleStatistic
                {
                    IsAscending = diffIsAsc,
                    Result = total
                },
                JobApplied = new SimpleStatistic
                {
                    IsAscending = diffIsAsc,
                    Result = total
                },
                JobView = new SimpleStatistic
                { 
                    IsAscending = false,
                    Result = total
                },
                GenderStatistic = new GenderStatistic
                { 
                    FemaleCountPercent = employees.Count(employee => employee.Gender == EmployeeGender.FEMALE),
                    MaleCountPercent = employees.Count(employee => employee.Gender == EmployeeGender.MALE)
                }
            };
        }
    }
}
