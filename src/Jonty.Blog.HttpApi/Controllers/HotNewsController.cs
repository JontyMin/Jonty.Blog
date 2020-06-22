﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Jonty.Blog.Application.Contracts.HotNews;
using Jonty.Blog.Application.Contracts.HotNews.Params;
using Jonty.Blog.Application.HotNews;
using Jonty.Blog.Domain.Shared;
using Jonty.Blog.ToolKits.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace Jonty.Blog.HttpApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [ApiExplorerSettings(GroupName = Grouping.GroupName_v3)]
    public class HotNewsController : AbpController
    {
        private readonly IHotNewsService _hotNewsService;

        public HotNewsController(IHotNewsService hotNewsService)
        {
            _hotNewsService = hotNewsService;
        }

        /// <summary>
        /// 获取每日热点来源列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("sources")]
        public async Task<ServiceResult<IEnumerable<EnumResponse>>> GetHotNewsSourceAsync()
        {
            return await _hotNewsService.GetHotNewsSourceAsync();
        }

        /// <summary>
        /// 根据来源获取每日热点列表
        /// </summary>
        /// <param name="sourceId"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ServiceResult<IEnumerable<HotNewsDto>>> QueryHotNewsAsync([Required] int sourceId)
        {
            return await _hotNewsService.QueryHotNewsAsync(sourceId);
        }

        /// <summary>
        /// 批量插入每日热点数据
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public async Task<ServiceResult<string>> BulkInsertHotNewsAsync([FromBody] BulkInsertHotNewsInput input)
        {
            return await _hotNewsService.BulkInsertHotNewsAsync(input);
        }
    }
}