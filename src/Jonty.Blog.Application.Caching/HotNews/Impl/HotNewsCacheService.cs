using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Jonty.Blog.Application.Contracts.HotNews;
using Jonty.Blog.Domain.Shared;
using Jonty.Blog.ToolKits.Base;
using Jonty.Blog.ToolKits.Extensions;

namespace Jonty.Blog.Application.Caching.HotNews.Impl
{
    public class HotNewsCacheService:JontyBlogApplicationCachingServiceBase,IHotNewsCacheService
    {
        private const string KEY_GetHotNewsSource = "HotNews:GetHotNewsSource";
        private const string KEY_QueryHotNews = "HotNews:QueryHotNews-{0}";

        /// <summary>
        /// 获取每日热点来源列表
        /// </summary>
        /// <param name="factory"></param>
        /// <returns></returns>
        public async Task<ServiceResult<IEnumerable<EnumResponse>>> GetHotNewsSourceAsync(Func<Task<ServiceResult<IEnumerable<EnumResponse>>>> factory)
        {
            return await Cache.GetOrAddAsync(KEY_GetHotNewsSource, factory, JontyBlogConsts.CacheStrategy.NEVER);
        }

        /// <summary>
        /// 根据来源获取每日热点列表
        /// </summary>
        /// <param name="sourceId"></param>
        /// <param name="factory"></param>
        /// <returns></returns>
        public async Task<ServiceResult<IEnumerable<HotNewsDto>>> QueryHotNewsAsync(int sourceId, Func<Task<ServiceResult<IEnumerable<HotNewsDto>>>> factory)
        {
            return await Cache.GetOrAddAsync(KEY_QueryHotNews.FormatWith(sourceId), factory, JontyBlogConsts.CacheStrategy.ONE_HOURS);
        }
    }
}