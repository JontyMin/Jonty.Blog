using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Jonty.Blog.Application.Contracts.HotNews;
using Jonty.Blog.ToolKits.Base;

namespace Jonty.Blog.Application.Caching.HotNews
{
    public interface IHotNewsCacheService
    {
        /// <summary>
        /// 获取每日热点来源列表
        /// </summary>
        /// <param name="factory"></param>
        /// <returns></returns>
        Task<ServiceResult<IEnumerable<EnumResponse>>> GetHotNewsSourceAsync(Func<Task<ServiceResult<IEnumerable<EnumResponse>>>> factory);

        /// <summary>
        /// 根据来源获取每日热点列表
        /// </summary>
        /// <param name="sourceId"></param>
        /// <param name="factory"></param>
        /// <returns></returns>
        Task<ServiceResult<IEnumerable<HotNewsDto>>> QueryHotNewsAsync(int sourceId, Func<Task<ServiceResult<IEnumerable<HotNewsDto>>>> factory);
    }
}