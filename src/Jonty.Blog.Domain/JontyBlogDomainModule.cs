using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace Jonty.Blog.Domain
{
    [DependsOn(typeof(AbpIdentityDomainModule))]
    public class JontyBlogDomainModule:AbpModule
    {
        
    }
}