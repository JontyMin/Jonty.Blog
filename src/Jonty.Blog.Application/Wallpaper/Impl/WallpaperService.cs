using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jonty.Blog.Application.Caching.Wallpaper;
using Jonty.Blog.Application.Contracts.Wallpaper;
using Jonty.Blog.Application.Contracts.Wallpaper.Params;
using Jonty.Blog.Domain.Shared;
using Jonty.Blog.Domain.Shared.Enum;
using Jonty.Blog.Domain.Wallpaper.Repositories;
using Jonty.Blog.ToolKits.Base;
using Jonty.Blog.ToolKits.Base.Paged;
using Jonty.Blog.ToolKits.Extensions;

namespace Jonty.Blog.Application.Wallpaper.Impl
{
    public class WallpaperService:JontyBlogApplicationServiceBase,IWallpaperService
    {
        private readonly IWallpaperCacheService _wallpaperCacheService;
        private readonly IWallpaperRepository _wallpaperRepository;

        public WallpaperService(IWallpaperCacheService wallpaperCacheService,
            IWallpaperRepository wallpaperRepository)
        {
            _wallpaperCacheService = wallpaperCacheService;
            _wallpaperRepository = wallpaperRepository;
        }
        /// <summary>
        /// 获取所有壁纸类型
        /// </summary>
        /// <returns></returns>
        public async Task<ServiceResult<IEnumerable<EnumResponse>>> GetWallpaperTypesAsync()
        {
            return await _wallpaperCacheService.GetWallpaperTypesAsync(async () =>
            {
                var result = new ServiceResult<IEnumerable<EnumResponse>>();

                var types = typeof(WallpaperEnum).TryToList();
                result.IsSuccess(types);

                return await Task.FromResult(result);
            });
        }

        /// <summary>
        /// 分页查询壁纸
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<ServiceResult<PagedList<WallpaperDto>>> QueryWallpapersAsync(QueryWallpapersInput input)
        {
            return await _wallpaperCacheService.QueryWallpapersAsync(input, async () =>
            {
                var result = new ServiceResult<PagedList<WallpaperDto>>();

                var query = _wallpaperRepository.WhereIf(input.Type > 0, x => x.Type == input.Type)
                                                .WhereIf(input.Keywords.IsNotNullOrEmpty(), x => x.Title.Contains(input.Keywords))
                                                .OrderByDescending(x => x.CreateTime);
                var count = query.Count();
                var wallpapers = query.PageByIndex(input.Page, input.Limit);

                var list = ObjectMapper.Map<IEnumerable<Domain.Wallpaper.Wallpaper>, List<WallpaperDto>>(wallpapers);

                result.IsSuccess(new PagedList<WallpaperDto>(count, list));
                return await Task.FromResult(result);
            });
        }

        /// <summary>
        /// 批量插入壁纸
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<ServiceResult<string>> BulkInsertWallpaperAsync(BulkInsertWallpaperInput input)
        {
            var result = new ServiceResult<string>();

            if (!input.Wallpapers.Any())
            {
                result.IsFailed(JontyBlogConsts.ResponseText.DATA_IS_NONE);
                return result;
            }

            var urls = _wallpaperRepository.Where(x => x.Type == (int)input.Type).Select(x => x.Url).ToList();

            var wallpapers = ObjectMapper.Map<IEnumerable<WallpaperDto>, IEnumerable<Domain.Wallpaper.Wallpaper>>(input.Wallpapers)
                .Where(x => !urls.Contains(x.Url));
            foreach (var item in wallpapers)
            {
                item.Type = (int)input.Type;
                item.CreateTime = item.Url.Split("/").Last().Split("_").First().TryToDateTime();
            }

            await _wallpaperRepository.BulkInsertAsync(wallpapers);

            result.IsSuccess(JontyBlogConsts.ResponseText.INSERT_SUCCESS);
            return result;
        }
    }
}