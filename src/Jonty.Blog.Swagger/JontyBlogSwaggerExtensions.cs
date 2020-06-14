using System;
using System.Collections.Generic;
using System.IO;
using Jonty.Blog.Configurations;
using Jonty.Blog.Swagger.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Jonty.Blog.Swagger
{
    public static class JontyBlogSwaggerExtensions
    {
        /// <summary>
        /// 当前API版本，从appsettings.json获取
        /// </summary>
        private static readonly string version = $"v{AppSettings.ApiVersion}";
        /// <summary>
        /// Swagger描述信息
        /// </summary>
        private static readonly string description = @"<b>Blog</b>：<a target=""_blank"" href=""https://www.jonty.top"">https://www.jonty.top</a> <b>GitHub</b>：<a target=""_blank"" href=""https://github.com/JontyMin/Jonty.Blog"">https://github.com/JontyMin/Jonty.Blog</a> <b>Hangfire</b>：<a target=""_blank"" href=""/hangfire"">任务调度中心</a> <code>Powered by .NET Core 3.1 on Linux</code>";

        private static readonly List<SwaggerApiInfo> ApiInfos = new List<SwaggerApiInfo>()
        {
            new SwaggerApiInfo
            {
                UrlPrefix = Grouping.GroupName_v1,
                Name = "博客前台接口",
                OpenApiInfo = new OpenApiInfo
                {
                    Version = version,
                    Title = "Jonty - 博客前台接口",
                    Description = description
                }
            },
            new SwaggerApiInfo
            {
                UrlPrefix = Grouping.GroupName_v2,
                Name = "博客后台接口",
                OpenApiInfo = new OpenApiInfo
                {
                    Version = version,
                    Title = "Jonty - 博客后台接口",
                    Description = description
                }
            },
            new SwaggerApiInfo
            {
                UrlPrefix = Grouping.GroupName_v3,
                Name = "通用公共接口",
                OpenApiInfo = new OpenApiInfo
                {
                    Version = version,
                    Title = "Jonty - 通用公共接口",
                    Description = description
                }
            },
            new SwaggerApiInfo
            {
                UrlPrefix = Grouping.GroupName_v4,
                Name = "JWT授权接口",
                OpenApiInfo = new OpenApiInfo
                {
                    Version = version,
                    Title = "Jonty - JWT授权接口",
                    Description = description
                }
            }
        };

        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            return services.AddSwaggerGen(options =>
            {
                //options.SwaggerDoc("v1",new OpenApiInfo()
                //{
                //    Version = "1.0.0",
                //    Title = "JontyBlog API",
                //    Description = "this is a api doc"
                //});

                // 遍历并应用Swagger分组信息
                ApiInfos.ForEach(x =>
                {
                    options.SwaggerDoc(x.UrlPrefix, x.OpenApiInfo);
                    //应用Controller的API文档描述信息
                    options.DocumentFilter<SwaggerDocumentFilter>();
                });

                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "Jonty.Blog.HttpApi.xml"));
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "Jonty.Blog.Domain.xml"));
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "Jonty.Blog.Application.Contracts.xml"));

                var security = new OpenApiSecurityScheme
                {
                    Description = "JWT模式授权，请输入Bearer{Token}进行身份认证",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                };

                options.AddSecurityDefinition("oauth2", security);
                options.AddSecurityRequirement(new OpenApiSecurityRequirement { { security, new List<string>() } });
                options.OperationFilter<AddResponseHeadersFilter>();
                options.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();
                options.OperationFilter<SecurityRequirementsOperationFilter>();

            });
        }

        public static void UseSwaggerUI(this IApplicationBuilder app)
        {
            //SwaggerDoc SwaggerEndpoint 对应api版本号相同 v1-v1

            //app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                //遍历分组信息,生成json
                ApiInfos.ForEach(x =>
                {
                    options.SwaggerEndpoint($"/swagger/{x.UrlPrefix}/swagger.json", x.Name);
                });
                
                // 模型的默认扩展深度，设置为-1完全隐藏模型
                options.DefaultModelExpandDepth(-1);
                //API文档仅展开标记
                options.DocExpansion(DocExpansion.List);
                // API前缀设置为空
                options.RoutePrefix = String.Empty;
                // API页面Title
                options.DocumentTitle = "接口文档 - Jonty";

            });
        }
    }

    internal class SwaggerApiInfo
    {
        /// <summary>
        /// Url前缀
        /// </summary>
        public string UrlPrefix { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Microsoft.OpenApi.Models.OpenApiInfo
        /// </summary>
        public OpenApiInfo OpenApiInfo { get; set; }

      
    }
}