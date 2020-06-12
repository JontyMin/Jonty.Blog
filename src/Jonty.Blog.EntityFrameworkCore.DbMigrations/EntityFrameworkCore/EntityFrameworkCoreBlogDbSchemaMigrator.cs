using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Jonty.Blog.Data;
using Volo.Abp.DependencyInjection;

namespace Jonty.Blog.EntityFrameworkCore
{
    public class EntityFrameworkCoreBlogDbSchemaMigrator
        : IBlogDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreBlogDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the BlogMigrationsDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<BlogMigrationsDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}