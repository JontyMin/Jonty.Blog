using Microsoft.Extensions.Caching.Distributed;
using Volo.Abp.DependencyInjection;

namespace Jonty.Blog.Application.Caching
{
    public class JontyBlogApplicationCachingServiceBase:ITransientDependency
    {
        public IDistributedCache Cache { get; set; }
    }
}