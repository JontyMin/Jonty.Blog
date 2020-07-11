using Jonty.Blog.Domain.Soul;
using Jonty.Blog.Domain.Soul.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using Jonty.Blog.Domain.Configurations;
using Jonty.Blog.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Jonty.Blog.EntityFrameworkCore.Repositories.Soul
{
    public class ChickenSoupRepository : EfCoreRepository<JontyBlogDbContext, ChickenSoup, int>, IChickenSoupRepository
    { 
        public ChickenSoupRepository(IDbContextProvider<JontyBlogDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
        /// <summary>
        /// 批量插入数据
        /// </summary>
        /// <param name="chickenSoups"></param>
        /// <returns></returns>
        public  async Task BulkInsertAsync(IEnumerable<ChickenSoup> chickenSoups)
        {
            await DbContext.Set<ChickenSoup>().AddRangeAsync(chickenSoups);
            await DbContext.SaveChangesAsync();
        }
        /// <summary>
        /// 随机获取数据
        /// </summary>
        /// <returns></returns>
        public async Task<ChickenSoup> GetRandomAsync()
        {
            var sql = string.Empty;
            switch (AppSettings.EnableDb)
            {
                case "MySql":
                    sql = $"SELECT * FROM {JontyBlogConsts.DbTablePrefix + JontyBlogDbConsts.DbTableName.ChickenSoups} ORDER BY RAND() LIMIT 1";
                    break;

                case "SqlServer":
                    sql = $"Select TOP 1 * FROM {JontyBlogConsts.DbTablePrefix + JontyBlogDbConsts.DbTableName.ChickenSoups} ORDER BY NEWID()";
                    break;

                case "PostgreSql":
                    sql = $"SELECT * FROM {JontyBlogConsts.DbTablePrefix + JontyBlogDbConsts.DbTableName.ChickenSoups} ORDER BY random() LIMIT 1";
                    break;

                case "Sqlite":
                    sql = $"SELECT * FROM {JontyBlogConsts.DbTablePrefix + JontyBlogDbConsts.DbTableName.ChickenSoups} ORDER BY RANDOM() LIMIT 1";
                    break;
            }
            return await DbContext.Set<ChickenSoup>().FromSqlRaw(sql).FirstOrDefaultAsync();
        }

       
    }
}