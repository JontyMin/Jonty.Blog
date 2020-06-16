using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Jonty.Blog.Domain.HotNews.Repositories;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Jonty.Blog.Repositories.HotNews
{
    public class HotNewsRepository:EfCoreRepository<JontyBlogDbContext,Domain.HotNews.HotNews,Guid>,IHotNewsRepository
    {
        public HotNewsRepository(IDbContextProvider<JontyBlogDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        /// <summary>
        /// 批量插入
        /// </summary>
        /// <param name="hotNews"></param>
        /// <returns></returns>
        public async Task BulkInsertAsync(IEnumerable<Domain.HotNews.HotNews> hotNews)
        {
            await DbContext.Set<Domain.HotNews.HotNews>().AddRangeAsync(hotNews);
            await DbContext.SaveChangesAsync();
        }
    }
}