using Blog.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.Api.Data
{
    public static class DbSeeder
    {
        public static async Task SeedAsync(BlogDbContext db)
        {
            if (await db.Posts.AnyAsync())
                return;

            DateTime now = DateTime.UtcNow;

            db.Posts.AddRange(
                new Post
                {
                    Title = "First Post",
                    Content = "Welcome to my first post!",
                    CreatedAt = now.AddDays(-3)
                },
                new Post
                {
                    Title = "Learning Angular",
                    Content = "Today learned standalone-components.",
                    CreatedAt = now.AddDays(-2)
                },
                new Post
                {
                    Title = "Writing this post",
                    Content = "Learning to fast blind typing. It's hard.",
                    CreatedAt = now.AddDays(-3)
                },
                new Post
                {
                    Title = "Wanna check time post",
                    Content = "This post will help me with checking time of posts I think.",
                    CreatedAt = now
                }
                );

            await db.SaveChangesAsync();
        }
    }
}
