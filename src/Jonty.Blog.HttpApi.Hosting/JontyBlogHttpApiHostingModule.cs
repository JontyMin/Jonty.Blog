using System;
using System.Linq;
using Jonty.Blog.BackgroundJobs;
using Jonty.Blog.BackgroundJobs.Jobs;
using Jonty.Blog.Domain.Configurations;
using Jonty.Blog.EntityFrameworkCore;
using Jonty.Blog.Swagger;
using Jonty.Blog.ToolKits.Base;
using Jonty.Blog.ToolKits.Extensions;
using Jonty.Blog.Web.Filters;
using Jonty.Blog.Web.Middleware;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Volo.Abp;
using Volo.Abp.AspNetCore;
using Volo.Abp.AspNetCore.Mvc.ExceptionHandling;
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
        typeof(JontyBlogFrameworkCoreModule),
        typeof(JontyBlogBackgroundJobsModule))]
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

                    //应用程序提供的对象，用于处理承载引发的事件，身份验证处理程序
                    options.Events = new JwtBearerEvents
                    {
                        OnChallenge = async context =>
                        {
                            // 跳过默认的处理逻辑，返回下面的模型数据
                            context.HandleResponse();

                            context.Response.ContentType = "application/json;charset=utf-8";
                            context.Response.StatusCode = StatusCodes.Status200OK;

                            var result = new ServiceResult();
                            result.IsFailed("UnAuthorized");

                            await context.Response.WriteAsync(result.ToJson());
                        }
                    };
                });

            // 认证授权
            context.Services.AddAuthentication();
            // Http请求
            context.Services.AddHttpClient();

            //异常处理
            Configure<MvcOptions>(options =>
            {
                var filterMetadata = options.Filters.FirstOrDefault(x => x is ServiceFilterAttribute attribute && attribute.ServiceType.Equals(typeof(AbpExceptionFilter)));

                // 移除 AbpExceptionFilter
                options.Filters.Remove(filterMetadata);

                // 添加JontyExceptionFilter
                options.Filters.Add(typeof(JontyBlogExceptionFilter));
            });

            //测试定时任务
            //context.Services.AddTransient<IHostedService, HelloWorldJob>();

            //路由规则配置
            context.Services.AddRouting(options =>
            {
                // 设置URL小写
                options.LowercaseUrls = true;
                // 在生成的URL后面添加斜杠
                options.AppendTrailingSlash = true;
            });
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
            //严格传输安全头
            app.UseHsts();

            // 转发将标头代理到当前请求，配合 Nginx 使用，获取用户真实IP
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            //路由
            app.UseRouting();

            //跨域
            app.UseCors(p => p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

            // 异常处理中间件
            app.UseMiddleware<ExceptionHandlerMiddleware>();

            //身份验证
            app.UseAuthentication();

            //认证授权
            app.UseAuthorization();
            
            // HTTP => HTTPS
            app.UseHttpsRedirection();

            //路由映射
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}