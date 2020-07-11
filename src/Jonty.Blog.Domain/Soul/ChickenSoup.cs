using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace Jonty.Blog.Domain.Soul
{
    public class ChickenSoup:Entity<int>
    {
        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }
    }
}
