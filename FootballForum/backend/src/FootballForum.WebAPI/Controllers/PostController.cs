// Controllers/PostController.cs
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FootballForum.Domain.Entities;
using FootballForum.Persistence.Context;

namespace FootballForum.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PostController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Post>>> GetPosts()
        {
            return await _context.Posts
                .Include(p => p.Team)
                .Include(p => p.Comments)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetPost(Guid id)
        {
            var post = await _context.Posts
                .Include(p => p.Team)
                .Include(p => p.Comments)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (post == null)
                return NotFound();

            return post;
        }

        [HttpGet("team/{teamId}")]
        public async Task<ActionResult<IEnumerable<Post>>> GetTeamPosts(Guid teamId)
        {
            return await _context.Posts
                .Include(p => p.Comments)
                .Where(p => p.TeamId == teamId)
                .ToListAsync();
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Post>> CreatePost(Post post)
        {
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPost), new { id = post.Id }, post);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePost(Guid id, Post post)
        {
            if (id != post.Id)
                return BadRequest();

            _context.Entry(post).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(Guid id)
        {
            var post = await _context.Posts.FindAsync(id);
            if (post == null)
                return NotFound();

            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
