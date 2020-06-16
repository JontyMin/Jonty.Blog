using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Jonty.Blog.Domain.Wallpaper.Repositories;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Jonty.Blog.Repositories.Wallpaper
{
    public class WallpaperRepository:EfCoreRepository<JontyBlogDbContext,Domain.Wallpaper.Wallpaper,Guid>,IWallpaperRepository
    {
        public WallpaperRepository(IDbContextProvider<JontyBlogDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        /// <summary>
        /// 批量插入
        /// </summary>
        /// <param name="wallpapers"></param>
        /// <returns></returns>
        public async Task BulkInsertAsync(IEnumerable<Domain.Wallpaper.Wallpaper> wallpapers)
        {
            await DbContext.Set<Domain.Wallpaper.Wallpaper>().AddRangeAsync(wallpapers);
            await DbContext.SaveChangesAsync();
        }
    }
}