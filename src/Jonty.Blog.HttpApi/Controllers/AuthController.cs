﻿using System.Threading.Tasks;
using Jonty.Blog.Application.Authorize;
using Jonty.Blog.Domain.Shared;
using Jonty.Blog.ToolKits.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace Jonty.Blog.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("[controller]")]
    [ApiExplorerSettings(GroupName = Grouping.GroupName_v4)]
    public class AuthController:AbpController
    {
        private readonly IAuthorizeService _authorizeService;

        public AuthController(IAuthorizeService authorizeService)
        {
            _authorizeService = authorizeService;
        }

        /// <summary>
        /// 获取登录地址(GitHub)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("url")]
        public async Task<ServiceResult<string>> GetLoginAddressAsync()
        {
            return await _authorizeService.GetLoginAddressAsync();
        }

        /// <summary>
        /// 获取AccessToken
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("access_token")]
        public async Task<ServiceResult<string>> GetAccessTokenAsync(string code)
        {
            return await _authorizeService.GetAccessTokenAsync(code);
        }

        /// <summary>
        /// 登录成功，生成Token
        /// </summary>
        /// <param name="access_token"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("token")]
        public async Task<ServiceResult<string>> GenerateTokenAsync(string access_token)
        {
            return await _authorizeService.GenerateTokenAsync(access_token);
        }
        /// <summary>
        /// 验证Token是否合法
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public async Task<ServiceResult> VerifyToken(string token)
        {
            return await _authorizeService.VerifyToken(token);
        }
    }
}