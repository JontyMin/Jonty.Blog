using Jonty.Blog.Domain;
using Jonty.Blog.Domain.Configurations;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Redis;
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
                //options.InstanceName = "blog-redis";
                //options.ConfigurationOptions
            });
            //var csredis = new CSRedis.CSRedisClient(AppSettings.Caching.RedisConnectionString);
            //RedisHelper.Initialization(csredis);

            //context.Services.AddSingleton<IDistributedCache>(new CSRedisCache(RedisHelper.Instance));
        }
    }
}