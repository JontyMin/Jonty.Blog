using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace Jonty.Blog
{
    [DependsOn(
        typeof(AbpIdentityApplicationModule)
        )]
    public class JontyBlogApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
           
        }
    }
}
