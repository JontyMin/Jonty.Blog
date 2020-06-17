using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jonty.Blog.Application.Contracts.Blog;
using Jonty.Blog.Domain.Shared;
using Jonty.Blog.ToolKits.Base;
using Jonty.Blog.ToolKits.Extensions;

namespace Jonty.Blog.Application.Blog.Impl
{
    public partial class BlogService
    {
        /// <summary>
        /// 查询分类列表
        /// </summary>
        /// <returns></returns>
        public async Task<ServiceResult<IEnumerable<QueryCategoryDto>>> QueryCategoriesAsync()
        {
            return await _blogCacheService.QueryCategoriesAsync(async () =>
            {
                var result = new ServiceResult<IEnumerable<QueryCategoryDto>>();

                var list = from category in await _categoryRepository.GetListAsync()
                    join posts in await _postRepository.GetListAsync()
                        on category.Id equals posts.CategoryId
                    group category by new
                    {
                        category.CategoryName,
                        category.DisplayName
                    } into g
                    select new QueryCategoryDto
                    {
                        CategoryName = g.Key.CategoryName,
                        DisplayName = g.Key.DisplayName,
                        Count = g.Count()
                    };

                result.IsSuccess(list);
                return result;
            });
        }
        /// <summary>
        /// 获取分类名称
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<ServiceResult<string>> GetCategoryAsync(string name)
        {
            return await _blogCacheService.GetCategoryAsync(name, async () =>
            {
                var result = new ServiceResult<string>();

                var category = await _categoryRepository.FindAsync(x => x.DisplayName.Equals(name));
                if (null == category)
                {
                    result.IsFailed(JontyBlogConsts.ResponseText.WHAT_NOT_EXIST.FormatWith("分类", name));
                    return result;
                }

                result.IsSuccess(category.CategoryName);
                return result;
            });
        }
    }
}
    

