using Jonty.Blog.Application.Caching;
using Volo.Abp.AutoMapper;
using Volo.Abp.Caching;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace Jonty.Blog.Application
{
    [DependsOn(
        typeof(AbpIdentityApplicationModule),
        typeof(AbpCachingModule),
        typeof(JontyBlogApplicationCachingModule),
        typeof(AbpAutoMapperModule)
    )]
    public class JontyBlogApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<JontyBlogApplicationModule>(validate: true);
                options.AddProfile<JontyBlogAutoMapperProfile>(validate:true);
            });
        }
    }
}
