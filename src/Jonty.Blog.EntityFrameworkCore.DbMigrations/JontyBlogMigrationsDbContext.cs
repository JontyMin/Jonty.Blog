using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Jonty.Blog
{
    public class JontyBlogMigrationsDbContext:AbpDbContext<JontyBlogMigrationsDbContext>
    {
        public JontyBlogMigrationsDbContext(DbContextOptions<JontyBlogMigrationsDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configure();
        }
    }
}