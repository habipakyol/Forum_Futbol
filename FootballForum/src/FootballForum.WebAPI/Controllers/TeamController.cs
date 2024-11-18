// Controllers/TeamController.cs
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FootballForum.Domain.Entities;
using FootballForum.Persistence.Context;

namespace FootballForum.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TeamController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Team>>> GetTeams()
        {
            return await _context.Teams.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Team>> GetTeam(Guid id)
        {
            var team = await _context.Teams.FindAsync(id);
            if (team == null)
                return NotFound();
            return team;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Team>> CreateTeam(Team team)
        {
            _context.Teams.Add(team);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTeam), new { id = team.Id }, team);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTeam(Guid id, Team team)
        {
            if (id != team.Id)
                return BadRequest();

            _context.Entry(team).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeam(Guid id)
        {
            var team = await _context.Teams.FindAsync(id);
            if (team == null)
                return NotFound();

            _context.Teams.Remove(team);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
