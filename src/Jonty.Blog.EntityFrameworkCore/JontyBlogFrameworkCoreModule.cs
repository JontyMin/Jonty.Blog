using Jonty.Blog.Configurations;
using Jonty.Blog.Domain;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.MySQL;
using Volo.Abp.EntityFrameworkCore.PostgreSql;
using Volo.Abp.EntityFrameworkCore.Sqlite;
using Volo.Abp.EntityFrameworkCore.SqlServer;
using Volo.Abp.Modularity;

namespace Jonty.Blog
{
    [DependsOn(
        typeof(JontyBlogDomainModule),
        typeof(AbpEntityFrameworkCoreModule),
        typeof(AbpEntityFrameworkCoreMySQLModule),
        typeof(AbpEntityFrameworkCoreSqlServerModule),
        typeof(AbpEntityFrameworkCorePostgreSqlModule),
        typeof(AbpEntityFrameworkCoreSqliteModule),
        typeof(JontyBlogDbContext))]
    public class JontyBlogFrameworkCoreModule:AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<JontyBlogDbContext>(options =>
            {
                //创建默认仓储
                options.AddDefaultRepositories(includeAllEntities: true);
            });

            Configure<AbpDbContextOptions>(options =>
            {
                switch (AppSettings.EnableDb)
                {
                    case "MySQL":
                        options.UseMySQL();
                        break;
                    case "SqlServer":
                        options.UseSqlServer();
                        break;
                    case "Sqlite":
                        options.UseSqlite();
                        break;
                    default:
                        options.UseMySQL();
                        break;
                }
            });
        }
    }
}