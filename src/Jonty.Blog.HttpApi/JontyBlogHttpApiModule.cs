using Jonty.Blog.Application;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace Jonty.Blog
{
    [DependsOn(
        typeof(AbpIdentityHttpApiModule),
        typeof(JontyBlogApplicationModule)
        )]
    public class JontyBlogHttpApiModule : AbpModule
    {
        
    }
}
