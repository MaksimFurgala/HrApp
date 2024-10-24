using AutoMapper;
using HrApp.Server.Data;
using HrApp.Server.Data.DtoModels;
using HrApp.Server.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HrApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CandidateController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper; 
        }

        /// <summary>
        /// Получения списка кандидатов.
        /// </summary>
        /// <returns>список кандидатов</returns>
        [HttpGet]
        public async Task<List<Candidate>> Get() => await _context.Candidates.ToListAsync();

        /// <summary>
        /// Получение иформации по кандидату через Id.
        /// </summary>
        /// <param name="id">id кандидата</param>
        /// <returns>информация по кандидату</returns>
        [HttpGet("{id}")]
        public async Task<CandidateDto> Get([FromQuery] int id)
        {
            var dbCandidate = await _context.Candidates.FirstOrDefaultAsync(c => c.Id == id);
            return _mapper.Map<CandidateDto>(dbCandidate);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CandidateDto candidate)
        {
            var dbCandidate = _mapper.Map<Candidate>(candidate);
            await _context.Candidates.AddAsync(dbCandidate);
            await _context.SaveChangesAsync();
            return Ok(dbCandidate.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] CandidateDto candidate)
        {
            var dbCandidate = _mapper.Map<Candidate>(candidate);
            _context.Candidates.Update(dbCandidate);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] CandidateDto candidate)
        {
            var dbCandidate = _mapper.Map<Candidate>(candidate);
            _context.Candidates.Remove(dbCandidate);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
