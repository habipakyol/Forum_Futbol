// Controllers/MatchController.cs
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FootballForum.Domain.Entities;
using FootballForum.Persistence.Context;


namespace FootballForum.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MatchController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Match>>> GetMatches()
        {
            return await _context.Matches
                .Include(m => m.HomeTeam)
                .Include(m => m.AwayTeam)
                .Include(m => m.MatchComments)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Match>> GetMatch(Guid id)
        {
            var match = await _context.Matches
                .Include(m => m.HomeTeam)
                .Include(m => m.AwayTeam)
                .Include(m => m.MatchComments)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (match == null)
                return NotFound();

            return match;
        }

        [HttpGet("team/{teamId}")]
        public async Task<ActionResult<IEnumerable<Match>>> GetTeamMatches(Guid teamId)
        {
            return await _context.Matches
                .Include(m => m.HomeTeam)
                .Include(m => m.AwayTeam)
                .Where(m => m.HomeTeamId == teamId || m.AwayTeamId == teamId)
                .ToListAsync();
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Match>> CreateMatch(Match match)
        {
            _context.Matches.Add(match);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetMatch), new { id = match.Id }, match);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMatch(Guid id, Match match)
        {
            if (id != match.Id)
                return BadRequest();

            _context.Entry(match).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMatch(Guid id)
        {
            var match = await _context.Matches.FindAsync(id);
            if (match == null)
                return NotFound();

            _context.Matches.Remove(match);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
