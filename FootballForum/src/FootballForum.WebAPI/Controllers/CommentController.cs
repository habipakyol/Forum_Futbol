// Controllers/CommentController.cs
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FootballForum.Domain.Entities;
using FootballForum.Persistence.Context;

namespace FootballForum.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CommentController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Comment>>> GetComments()
        {
            return await _context.Comments
                .Include(c => c.Post)
                .Include(c => c.Match)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Comment>> GetComment(Guid id)
        {
            var comment = await _context.Comments
                .Include(c => c.Post)
                .Include(c => c.Match)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (comment == null)
                return NotFound();

            return comment;
        }

        [HttpGet("post/{postId}")]
        public async Task<ActionResult<IEnumerable<Comment>>> GetPostComments(Guid postId)
        {
            return await _context.Comments
                .Where(c => c.PostId == postId)
                .ToListAsync();
        }

        [HttpGet("match/{matchId}")]
        public async Task<ActionResult<IEnumerable<Comment>>> GetMatchComments(Guid matchId)
        {
            return await _context.Comments
                .Where(c => c.MatchId == matchId)
                .ToListAsync();
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Comment>> CreateComment(Comment comment)
        {
            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetComment), new { id = comment.Id }, comment);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateComment(Guid id, Comment comment)
        {
            if (id != comment.Id)
                return BadRequest();

            _context.Entry(comment).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment(Guid id)
        {
            var comment = await _context.Comments.FindAsync(id);
            if (comment == null)
                return NotFound();

            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
