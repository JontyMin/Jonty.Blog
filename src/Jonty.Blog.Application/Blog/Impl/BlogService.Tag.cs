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
        /// 查询标签列表
        /// </summary>
        /// <returns></returns>
        public async Task<ServiceResult<IEnumerable<QueryTagDto>>> QueryTagsAsync()
        {
            return await _blogCacheService.QueryTagsAsync(async () =>
            {
                var result = new ServiceResult<IEnumerable<QueryTagDto>>();

                var list = from tags in await _tagRepository.GetListAsync()
                    join post_tags in await _postTagRepository.GetListAsync()
                        on tags.Id equals post_tags.TagId
                    group tags by new
                    {
                        tags.TagName,
                        tags.DisplayName
                    } into g
                    select new QueryTagDto
                    {
                        TagName = g.Key.TagName,
                        DisplayName = g.Key.DisplayName,
                        Count = g.Count()
                    };

                result.IsSuccess(list);
                return result;
            });
        }
        /// <summary>
        /// 获取标签名称
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<ServiceResult<string>> GetTagAsync(string name)
        {
            return await _blogCacheService.GetTagAsync(name, async () =>
            {
                var result = new ServiceResult<string>();

                var tag = await _tagRepository.FindAsync(x => x.DisplayName.Equals(name));
                if (null == tag)
                {
                    result.IsFailed(JontyBlogConsts.ResponseText.WHAT_NOT_EXIST.FormatWith("标签", name));
                    return result;
                }

                result.IsSuccess(tag.TagName);
                return result;
            });
        }
    }
}
