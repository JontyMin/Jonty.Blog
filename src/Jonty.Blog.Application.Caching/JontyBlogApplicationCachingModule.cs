using Jonty.Blog.Configurations;
using Jonty.Blog.Domain;
using Microsoft.Extensions.DependencyInjection;
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
            //base.ConfigureServices(context);
            context.Services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = AppSettings.Caching.RedisConnectionString;
                //实例名
                options.InstanceName = "blog-redis";
                //options.ConfigurationOptions
            });
        }
    }
}