using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Jonty.Blog
{
    public class JontyBlogMigrationsDbContextFactory:IDesignTimeDbContextFactory<JontyBlogMigrationsDbContext>
    {
        public JontyBlogMigrationsDbContext CreateDbContext(string[] args)
        {
            var configuration = BuildConfiguration();
            var builder = new DbContextOptionsBuilder<JontyBlogMigrationsDbContext>()
                .UseMySql(configuration.GetConnectionString("MySql"));

            return new JontyBlogMigrationsDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            return builder.Build();
        }
    }
}