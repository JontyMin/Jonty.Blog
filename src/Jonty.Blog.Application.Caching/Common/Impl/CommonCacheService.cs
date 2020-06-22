﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Jonty.Blog.Domain.Shared;
using Jonty.Blog.ToolKits.Base;
using Jonty.Blog.ToolKits.Extensions;

namespace Jonty.Blog.Application.Caching.Common.Impl
{
    public class CommonCacheService:JontyBlogApplicationCachingServiceBase,ICommonCacheService
    {
        private const string KEY_GetBingImgUrl = "Common:Bing:ImgUrl";
        private const string KEY_GetBingImgFile = "Common:Bing:ImgFile";
        private const string KEY_GetGirls = "Common:Girls:Get";
        private const string KEY_GetGirlImgFile = "Common:Girls:ImgFile-{0}";
        private const string KEY_GetCats = "Common:Cats:Get";
        private const string KEY_GetCatImgFile = "Common:Cat:ImgFile-{0}";
        private const string KEY_Ip2Regin = "Common:Ip:Ip2Regin-{0}";
        private const string KEY_SpeechTts = "Common:SpeechTts:{0}-{1}-{2}-{3}-{4}";
        private const string KEY_SpeechTtsGreetWord = "Common:SpeechTts:GreetWord";

        /// <summary>
        /// 获取必应每日壁纸，返回图片URL
        /// </summary>
        /// <param name="factory"></param>
        /// <returns></returns>
        public async Task<ServiceResult<string>> GetBingImgUrlAsync(Func<Task<ServiceResult<string>>> factory)
        {
            return await Cache.GetOrAddAsync(KEY_GetBingImgUrl, factory, JontyBlogConsts.CacheStrategy.HALF_DAY);
        }

        /// <summary>
        /// 获取必应每日壁纸，直接返回图片
        /// </summary>
        /// <param name="factory"></param>
        /// <returns></returns>
        public async Task<ServiceResult<byte[]>> GetBingImgFileAsync(Func<Task<ServiceResult<byte[]>>> factory)
        {
            return await Cache.GetOrAddAsync(KEY_GetBingImgFile, factory, JontyBlogConsts.CacheStrategy.HALF_DAY);
        }

        /// <summary>
        /// 获取妹子图，返回URL列表
        /// </summary>
        /// <param name="factory"></param>
        /// <returns></returns>
        public async Task<ServiceResult<IEnumerable<string>>> GetGirlsAsync(Func<Task<ServiceResult<IEnumerable<string>>>> factory)
        {
            return await Cache.GetOrAddAsync(KEY_GetGirls, factory, JontyBlogConsts.CacheStrategy.ONE_DAY);
        }

        /// <summary>
        /// 获取妹子图，直接返回图片
        /// </summary>
        /// <param name="url"></param>
        /// <param name="factory"></param>
        /// <returns></returns>
        public async Task<ServiceResult<byte[]>> GetGirlImgFileAsync(string url, Func<Task<ServiceResult<byte[]>>> factory)
        {
            return await Cache.GetOrAddAsync(KEY_GetGirlImgFile.FormatWith(url.EncodeMd5String()), factory, JontyBlogConsts.CacheStrategy.NEVER);
        }

        /// <summary>
        /// 获取一张猫图，返回URL列表
        /// </summary>
        /// <param name="factory"></param>
        /// <returns></returns>
        public async Task<ServiceResult<IEnumerable<string>>> GetCatsAsync(Func<Task<ServiceResult<IEnumerable<string>>>> factory)
        {
            return await Cache.GetOrAddAsync(KEY_GetCats, factory, JontyBlogConsts.CacheStrategy.ONE_DAY);
        }

        /// <summary>
        /// 获取一张猫图，直接返回图片
        /// </summary>
        /// <param name="url"></param>
        /// <param name="factory"></param>
        /// <returns></returns>
        public async Task<ServiceResult<byte[]>> GetCatImgFileAsync(string url, Func<Task<ServiceResult<byte[]>>> factory)
        {
            return await Cache.GetOrAddAsync(KEY_GetCatImgFile.FormatWith(url.EncodeMd5String()), factory, JontyBlogConsts.CacheStrategy.NEVER);
        }

        /// <summary>
        /// 根据IP地址获取所在区域
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="factory"></param>
        /// <returns></returns>
        public async Task<ServiceResult<string>> Ip2ReginAsync(string ip, Func<Task<ServiceResult<string>>> factory)
        {
            return await Cache.GetOrAddAsync(KEY_Ip2Regin.FormatWith(ip), factory, JontyBlogConsts.CacheStrategy.ONE_DAY);
        }

        /// <summary>
        /// 语音合成
        /// </summary>
        /// <param name="content"></param>
        /// <param name="spd"></param>
        /// <param name="pit"></param>
        /// <param name="vol"></param>
        /// <param name="per"></param>
        /// <param name="factory"></param>
        /// <returns></returns>
        public async Task<ServiceResult<byte[]>> SpeechTtsAsync(string content, int spd, int pit, int vol, int per, Func<Task<ServiceResult<byte[]>>> factory)
        {
            return await Cache.GetOrAddAsync(KEY_SpeechTts.FormatWith(content.EncodeMd5String(), spd, pit, vol, per), factory, JontyBlogConsts.CacheStrategy.ONE_DAY);
        }

        /// <summary>
        /// 语音合成欢迎词
        /// </summary>
        /// <param name="factory"></param>
        /// <returns></returns>
        public async Task<ServiceResult<byte[]>> SpeechTtsGreetWordAsync(Func<Task<ServiceResult<byte[]>>> factory)
        {
            return await Cache.GetOrAddAsync(KEY_SpeechTtsGreetWord, factory, JontyBlogConsts.CacheStrategy.ONE_HOURS);
        }
    }
}