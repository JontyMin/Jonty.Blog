﻿using System.Collections.Generic;

namespace Jonty.Blog.BlazorApp.Response.Blog
{
    public class QueryPostForAdminDto: QueryPostDto
    {
        /// <summary>
        /// Posts
        /// </summary>
        public new IEnumerable<PostBriefForAdminDto> Posts { get; set; }
    }
}