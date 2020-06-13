using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Jonty.Blog.Domain.Blog.Repositories
{
    /// <summary>
    /// IPostTagRepository
    /// </summary>
    public interface ITagRepository:IRepository<Tag,int>
    {
        /// <summary>
        /// 批量插入
        /// </summary>
        /// <param name="tags"></param>
        /// <returns></returns>
        Task BulkInsertAsync(IEnumerable<Tag> tags);
    }
}