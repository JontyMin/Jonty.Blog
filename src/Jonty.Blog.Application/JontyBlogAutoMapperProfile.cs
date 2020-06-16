using AutoMapper;
using Jonty.Blog.Blog;
using Jonty.Blog.Domain.Blog;

namespace Jonty.Blog
{
    public class JontyBlogAutoMapperProfile:Profile
    {
        public JontyBlogAutoMapperProfile()
        {
            CreateMap<Post, PostDto>();
            CreateMap<PostDto, Post>().ForMember(x => x.Id, opt => opt.Ignore());
        }
    }
}