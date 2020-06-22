using System.Collections.Generic;
using Jonty.Blog.Domain.Shared.Enum;

namespace Jonty.Blog.Application.Contracts.HotNews.Params
{
    public class BulkInsertHotNewsInput
    {
        /// <summary>
        /// 来源
        /// </summary>
        public HotNewsEnum Source { get; set; }

        /// <summary>
        /// 每日热点列表
        /// </summary>
        public IEnumerable<HotNewsDto> HotNews { get; set; }
    }
}