using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Jonty.Blog.Application.Contracts;
using Jonty.Blog.Application.Contracts.Blog;
using Jonty.Blog.Domain.Shared;
using Jonty.Blog.ToolKits.Base;
using Jonty.Blog.ToolKits.Base.Paged;
using Jonty.Blog.ToolKits.Extensions;

namespace Jonty.Blog.Application.Caching.Blog.Impl
{
    public partial class BlogCacheService
    {
        private const string KEY_QueryPosts = "Blog:Post:QueryPosts-{0}-{1}";
        private const string KEY_GetPostDetail = "Blog:Post:GetPostDetail-{0}";
        /// <summary>
        /// 分页查询文章列表
        /// </summary>
        /// <param name="input"></param>
        /// <param name="factory"></param>
        /// <returns></returns>
        public async Task<ServiceResult<PagedList<QueryPostDto>>> QueryPostsAsync(PagingInput input, Func<Task<ServiceResult<PagedList<QueryPostDto>>>> factory)
        {
            return await Cache.GetOrAddAsync(KEY_QueryPosts.FormatWith(input.Page, input.Limit), factory, JontyBlogConsts.CacheStrategy.ONE_DAY);
        }
        /// <summary>
        /// 根据URL获取文章详情
        /// </summary>
        /// <param name="url"></param>
        /// <param name="factory"></param>
        /// <returns></returns>
        public async Task<ServiceResult<PostDetailDto>> GetPostDetailAsync(string url, Func<Task<ServiceResult<PostDetailDto>>> factory)
        {
            return await Cache.GetOrAddAsync(KEY_GetPostDetail.FormatWith(url), factory, JontyBlogConsts.CacheStrategy.ONE_DAY);
        }
    }
}
