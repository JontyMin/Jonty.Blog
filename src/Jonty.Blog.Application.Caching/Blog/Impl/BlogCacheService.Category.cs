using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Jonty.Blog.Application.Contracts.Blog;
using Jonty.Blog.Domain.Shared;
using Jonty.Blog.ToolKits.Base;
using Jonty.Blog.ToolKits.Extensions;

namespace Jonty.Blog.Application.Caching.Blog.Impl
{
    public partial class BlogCacheService
    {
        private const string KEY_QueryCategories = "Blog:Category:QueryCategories"; 
        private const string KEY_GetCategory = "Blog:Category:GetCategory-{0}";
        /// <summary>
        /// 查询分类列表
        /// </summary>
        /// <param name="factory"></param>
        /// <returns></returns>
        public async Task<ServiceResult<IEnumerable<QueryCategoryDto>>> QueryCategoriesAsync(Func<Task<ServiceResult<IEnumerable<QueryCategoryDto>>>> factory)
        {
            return await Cache.GetOrAddAsync(KEY_QueryCategories, factory, JontyBlogConsts.CacheStrategy.ONE_DAY);
        }
       

        /// <summary>
        /// 获取分类名称
        /// </summary>
        /// <param name="name"></param>
        /// <param name="factory"></param>
        /// <returns></returns>
        public async Task<ServiceResult<string>> GetCategoryAsync(string name, Func<Task<ServiceResult<string>>> factory)
        {
            return await Cache.GetOrAddAsync(KEY_GetCategory.FormatWith(name), factory, JontyBlogConsts.CacheStrategy.ONE_DAY);
        }
    }
}
