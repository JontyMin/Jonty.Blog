using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Volo.Abp;
using Volo.Abp.AspNetCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Jonty.Blog.Web
{
    //新建此类后安装abp autofac依赖
    //Install-Package Volo.Abp.Autofac

    //abp中每个模块都应自定义一个模块类，派生自AbpModule

    [DependsOn(typeof(AbpAspNetCoreModule),
        typeof(AbpAutofacModule),
        typeof(JontyBlogHttpApiModule))]
    public class JontyBlogHttpApiHostingModule:AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            base.ConfigureServices(context);
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            var env = context.GetEnvironment();

            //环境变量，开发环境
            if (env.IsDevelopment())
            {
                //生成异常页面
                app.UseDeveloperExceptionPage();
            }

            //路由
            app.UseRouting();

            //路由映射
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}