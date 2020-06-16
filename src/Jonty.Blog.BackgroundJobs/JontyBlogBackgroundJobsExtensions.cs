using System;
using Hangfire;
using Jonty.Blog.BackgroundJobs.Jobs.Hangfire;
using Jonty.Blog.BackgroundJobs.Jobs.HotNews;
using Jonty.Blog.BackgroundJobs.Jobs.Wallpaper;
using Microsoft.Extensions.DependencyInjection;

namespace Jonty.Blog.BackgroundJobs
{
    public static class JontyBlogBackgroundJobsExtensions
    {
        /// <summary>
        /// 定时任务测试
        /// </summary>
        /// <param name="service"></param>
        public static void UseHangfireTest(this IServiceProvider service)
        {
            var job = service.GetService<HangfireTestJob>();
            //定期作业按指定的计划触发任务
            RecurringJob.AddOrUpdate("定时任务测试",()=>job.ExecuteAsync(), JontyBlogCronType.Minute());
        }

        /// <summary>
        /// 壁纸数据抓取
        /// </summary>
        /// <param name="service"></param>
        public static void UseWallpaperJob(this IServiceProvider service)
        {
            var job = service.GetService<WallpaperJob>();

            RecurringJob.AddOrUpdate("壁纸数据抓取", () => job.ExecuteAsync(), JontyBlogCronType.Hour(1, 3));
        }

        /// <summary>
        /// 每日热点数据抓取
        /// </summary>
        /// <param name="context"></param>
        public static void UseHotNewsJob(this IServiceProvider service)
        {
            var job = service.GetService<HotNewsJob>();

            RecurringJob.AddOrUpdate("每日热点数据抓取", () => job.ExecuteAsync(), JontyBlogCronType.Hour(1, 2));
        }

    }
}