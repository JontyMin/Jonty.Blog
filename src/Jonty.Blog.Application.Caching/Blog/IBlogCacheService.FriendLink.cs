using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Jonty.Blog.Application.Contracts.Blog;
using Jonty.Blog.ToolKits.Base;

namespace Jonty.Blog.Application.Caching.Blog
{
    public partial interface IBlogCacheService
    {
        /// <summary>
        /// 查询友链列表
        /// </summary>
        /// <param name="factory"></param>
        /// <returns></returns>
        Task<ServiceResult<IEnumerable<FriendLinkDto>>> QueryFriendLinksAsync(Func<Task<ServiceResult<IEnumerable<FriendLinkDto>>>> factory);
    }
}
