using System.Collections.Generic;

namespace Jonty.Blog.ToolKits.Base.Paged
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