using Jonty.Blog.Domain;
using Volo.Abp.Caching;
using Volo.Abp.Modularity;

namespace Jonty.Blog.Application.Caching
{
    [DependsOn(typeof(AbpCachingModule),
        typeof(JontyBlogDomainModule))]
    public class JontyBlogApplicationCachingModule: AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            base.ConfigureServices(context);
        }
    }
}