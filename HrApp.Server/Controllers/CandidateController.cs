using HrApp.Server.Data;
using HrApp.Server.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HrApp.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CandidateController(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Получения списка кандидатов.
        /// </summary>
        /// <returns>список кандидатов</returns>
        [HttpGet]
        public async Task<List<Candidate>> GetCandidates() => await _context.Candidates.ToListAsync();
    }
}
