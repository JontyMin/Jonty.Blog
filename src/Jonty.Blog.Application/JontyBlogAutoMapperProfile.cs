using AutoMapper;
using Jonty.Blog.Application.Contracts.Blog;
using Jonty.Blog.Application.Contracts.Blog.Params;
using Jonty.Blog.Domain.Blog;

namespace Jonty.Blog.Application
{
    public class JontyBlogAutoMapperProfile:Profile
    {
        public JontyBlogAutoMapperProfile()
        {
            CreateMap<Post, PostDto>();
            CreateMap<PostDto, Post>().ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<EditPostInput, Post>().ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<Post, PostForAdminDto>().ForMember(x => x.Tags, opt => opt.Ignore());
            CreateMap<EditCategoryInput, Category>().ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<EditTagInput, Tag>().ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<FriendLink, QueryFriendLinkForAdminDto>();
            CreateMap<EditFriendLinkInput, FriendLink>().ForMember(x => x.Id, opt => opt.Ignore());
        }
    }
}