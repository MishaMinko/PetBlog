using Blog.Api.Data;
using Blog.Api.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly BlogDbContext _db;
        public PostsController(BlogDbContext db) => _db = db;

        [HttpGet]
        public async Task<ActionResult<List<Post>>> GetAll()
            => await _db.Posts.OrderByDescending(p => p.CreatedAt).ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetById(int id)
        {
            Post? post = await _db.Posts.FindAsync(id);

            if (post == null)
                return NotFound();

            return post;
        }

        [HttpPost]
        public async Task<ActionResult> Create(Post post)
        {
            post.CreatedAt = DateTime.UtcNow;
            _db.Posts.Add(post);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = post.Id }, post);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Post updated)
        {
            Post? post = await _db.Posts.FindAsync(id);

            if (post == null)
                return NotFound();

            post.Title = updated.Title;
            post.Content = updated.Content;
            post.UpdatedAt = DateTime.UtcNow;
            await _db.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            Post? post = await _db.Posts.FindAsync(id);

            if (post == null)
                return NotFound();

            _db.Posts.Remove(post);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}
