using AutoMapper;
using HrApp.Server.Data;
using HrApp.Server.Data.DtoModels;
using HrApp.Server.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HrApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssueController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public IssueController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<List<IssueDto>> Get()
        {
            var dbIssue = await _context.Issues.ToListAsync();
            return _mapper.Map<List<IssueDto>>(dbIssue);
        }

        [HttpGet("{id}")]
        public async Task<IssueDto> Get([FromQuery] int id)
        {
            var dbIssue = await _context.Issues.FirstOrDefaultAsync(issue => issue.Id == id);
            return _mapper.Map<IssueDto>(dbIssue);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] IssueDto issueDto)
        {
            var dbIssue = _mapper.Map<Issue>(issueDto);
            await _context.Issues.AddAsync(dbIssue);
            await _context.SaveChangesAsync();
            return Ok(dbIssue.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] IssueDto issueDto)
        {
            var dbIssue = _mapper.Map<Issue>(issueDto);
            _context.Issues.Update(dbIssue);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] IssueDto issueDto)
        {
            var dbIssue = _mapper.Map<Issue>(issueDto);
            _context.Issues.Remove(dbIssue);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
