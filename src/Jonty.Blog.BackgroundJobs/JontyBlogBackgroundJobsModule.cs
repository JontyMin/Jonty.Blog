using Hangfire;
using Hangfire.Dashboard.BasicAuthorization;
using Hangfire.MySql.Core;
using Jonty.Blog.Configurations;
using Volo.Abp;
using Volo.Abp.BackgroundJobs.Hangfire;
using Volo.Abp.Modularity;

namespace Jonty.Blog.BackgroundJobs
{
    [DependsOn(typeof(AbpBackgroundJobsHangfireModule))]
    public class JontyBlogBackgroundJobsModule:AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            //base.ConfigureServices(context);
            context.Services.AddHangfire(config =>
            {
                //配置MySql连接字符串
                config.UseStorage(
                    new MySqlStorage(AppSettings.ConnectionStrings,
                        new MySqlStorageOptions
                        {
                            TablePrefix = JontyBlogConsts.DbTablePrefix+"hangfire"
                        })
                );
            });
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            //base.OnApplicationInitialization(context);
            var app = context.GetApplicationBuilder();
            app.UseHangfireServer();
            app.UseHangfireDashboard(options:new DashboardOptions
            {
               Authorization = new []
               {
                   new BasicAuthAuthorizationFilter(new BasicAuthAuthorizationFilterOptions
                   {
                       RequireSsl = false,
                       SslRedirect = false,
                       LoginCaseSensitive = true,
                       Users = new []
                       {
                           new BasicAuthAuthorizationUser
                           {
                               Login = AppSettings.Hangfire.Login,
                               PasswordClear = AppSettings.Hangfire.Password
                           }
                       }
                   })
                },
               DashboardTitle = "任务调度中心"
            });

            // 获取IServiceProvider
            var service = context.ServiceProvider;
            // 调用定时任务
            //service.UseHangfireTest();

            //定时抓取图片
            service.UseWallpaperJob();

            //热点数据抓取
            service.UseHotNewsJob();
        }
    }
}