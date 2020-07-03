using System.Collections.Generic;

namespace Jonty.Blog.BlazorApp.Response.Blog
{
    public class QueryPostForAdminDto
    {
        /// <summary>
        /// 年份
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// Posts
        /// </summary>
        public IEnumerable<PostBriefForAdminDto> Posts { get; set; }
    }
}