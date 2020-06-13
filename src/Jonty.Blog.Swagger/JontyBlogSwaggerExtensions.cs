using System;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Jonty.Blog.Swagger
{
    public static class JontyBlogSwaggerExtensions
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            return services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1",new OpenApiInfo()
                {
                    Version = "1.0.0",
                    Title = "JontyBlog API",
                    Description = "this is a api doc"
                });
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "Jonty.Blog.HttpApi.xml"));
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "Jonty.Blog.Domain.xml"));
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "Jonty.Blog.Application.Contracts.xml"));
            
        });
        }

        public static void UseSwaggerUI(this IApplicationBuilder app)
        {
            //SwaggerDoc SwaggerEndpoint 对应api版本号相同 v1-v1

            //app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint($"/swagger/v1/swagger.json", "default api");
            });
        }
    }
}