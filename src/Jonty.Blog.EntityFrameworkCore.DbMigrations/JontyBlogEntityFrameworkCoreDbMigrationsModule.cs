using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace Jonty.Blog
{
    [DependsOn(typeof(JontyBlogFrameworkCoreModule))]
    public class JontyBlogEntityFrameworkCoreDbMigrationsModule:AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<JontyBlogMigrationsDbContext>();
        }
    }
}