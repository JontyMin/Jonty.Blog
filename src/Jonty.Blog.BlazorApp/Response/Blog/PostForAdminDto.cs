﻿using System.Collections.Generic;

namespace Jonty.Blog.BlazorApp.Response.Blog
{
    public class PostForAdminDto:PostDto
    {
        /// <summary>
        /// 标签列表
        /// </summary>
        public IEnumerable<string> Tags { get; set; }
    }
}