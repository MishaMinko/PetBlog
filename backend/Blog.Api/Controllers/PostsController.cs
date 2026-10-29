using Blog.Api.Data;
using Blog.Api.Models;
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
    }
}
