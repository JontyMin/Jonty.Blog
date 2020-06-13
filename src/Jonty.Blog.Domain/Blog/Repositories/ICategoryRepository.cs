using Volo.Abp.Domain.Repositories;

namespace Jonty.Blog.Domain.Blog.Repositories
{
    /// <summary>
    /// IPostTagRepository
    /// </summary>
    public interface ICategoryRepository:IRepository<Category,int>
    {
        
    }
}