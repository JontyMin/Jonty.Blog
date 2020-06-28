using System.Collections.Generic;
using Jonty.Blog.BlazorApp.Response.Base.Paged;

namespace Jonty.Blog.BlazorApp.Response.Base
{
    public class PagedList<T>:ListResult<T>,IPagedList<T>
    {
        /// <summary>
        /// 总数
        /// </summary>
        public int Total { get; set; }
        public PagedList(){}

        public PagedList(int total, IReadOnlyList<T> result) : base(result)
        {
            Total = total;
        }
    }
}