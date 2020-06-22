using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Jonty.Blog.Application.Contracts.Wallpaper;
using Jonty.Blog.Application.Contracts.Wallpaper.Params;
using Jonty.Blog.ToolKits.Base;
using Jonty.Blog.ToolKits.Base.Paged;

namespace Jonty.Blog.Application.Caching.Wallpaper
{
    public interface IWallpaperCacheService
    {
        /// <summary>
        /// 获取所有壁纸类型
        /// </summary>
        /// <param name="factory"></param>
        /// <returns></returns>
        Task<ServiceResult<IEnumerable<EnumResponse>>> GetWallpaperTypesAsync(Func<Task<ServiceResult<IEnumerable<EnumResponse>>>> factory);

        /// <summary>
        /// 分页查询壁纸
        /// </summary>
        /// <param name="input"></param>
        /// <param name="factory"></param>
        /// <returns></returns>
        Task<ServiceResult<PagedList<WallpaperDto>>> QueryWallpapersAsync(QueryWallpapersInput input, Func<Task<ServiceResult<PagedList<WallpaperDto>>>> factory);
    }
}