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
        }
    }
}