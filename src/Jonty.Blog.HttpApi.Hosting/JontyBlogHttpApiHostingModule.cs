using System;
using Jonty.Blog.Configurations;
using Jonty.Blog.Swagger;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
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
        typeof(JontyBlogHttpApiModule),
        typeof(JontyBlogHttpApiModule),
        typeof(JontyBlogSwaggerModule),
        typeof(JontyBlogFrameworkCoreModule))]
    public class JontyBlogHttpApiHostingModule:AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            //base.ConfigureServices(context);

            // 身份验证  
            context.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        // 验证颁发者
                        ValidateIssuer = true,
                        // 验证访问群体
                        ValidateAudience = true,
                        // 验证生存期
                        ValidateLifetime = true,
                        // 验证Token时间偏移量
                        ClockSkew = TimeSpan.FromSeconds(30),
                        // 验证安全密匙
                        ValidateIssuerSigningKey = true,
                        // 访问群体
                        ValidAudience = AppSettings.JWT.Domain,
                        // 颁发者
                        ValidIssuer = AppSettings.JWT.Domain,
                        // 安全密匙
                        IssuerSigningKey = new SymmetricSecurityKey(AppSettings.JWT.SecurityKey.GetBytes())
                        
                    };
                });

            // 认证授权
            context.Services.AddAuthentication();
            // Http请求
            context.Services.AddHttpClient();
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

            //身份验证
            app.UseAuthentication();

            //认证授权
            app.UseAuthorization();

            //路由映射
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}