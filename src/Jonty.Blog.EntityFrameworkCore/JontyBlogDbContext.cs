using Jonty.Blog.Domain.Blog;
using Jonty.Blog.Domain.HotNews;
using Jonty.Blog.Domain.Wallpaper;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Jonty.Blog.EntityFrameworkCore
{
    [ConnectionStringName("MySql")]
    public class JontyBlogDbContext:AbpDbContext<JontyBlogDbContext>
    {
        public JontyBlogDbContext(DbContextOptions<JontyBlogDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configure();
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<PostTag> PostTags { get; set; }
        public DbSet<FriendLink> FriendLinks { get; set; }
        public DbSet<Wallpaper> Wallpapers { get; set; }
        public DbSet<HotNews> HotNews { get; set; }
    }
}