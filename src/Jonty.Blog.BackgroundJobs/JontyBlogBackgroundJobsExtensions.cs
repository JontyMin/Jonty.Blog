using System;
using Hangfire;
using Jonty.Blog.BackgroundJobs.Jobs.Hangfire;
using Microsoft.Extensions.DependencyInjection;

namespace Jonty.Blog.BackgroundJobs
{
    public static class JontyBlogBackgroundJobsExtensions
    {

        public static void UseHangfireTest(this IServiceProvider service)
        {
            var job = service.GetService<HangfireTestJob>();
            //定期作业按指定的计划触发任务
            RecurringJob.AddOrUpdate("定时任务测试",()=>job.ExecuteAsync(), JontyBlogCronType.Minute());
        }
    }
}