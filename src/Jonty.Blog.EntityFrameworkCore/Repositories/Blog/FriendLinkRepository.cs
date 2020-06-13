using Jonty.Blog.Domain.Blog;
using Jonty.Blog.Domain.Blog.Repositories;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Jonty.Blog.Repositories.Blog
{
    /// <summary>
    /// FriendLinkRepository
    /// </summary>
    public class FriendLinkRepository:EfCoreRepository<JontyBlogDbContext,FriendLink,int>,IFriendLinkRepository
    {
        public FriendLinkRepository(IDbContextProvider<JontyBlogDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}