using Jonty.Blog.Application;
using Jonty.Blog.Domain.Blog.Repositories;
using System;
using System.Threading.Tasks;
using Jonty.Blog.Domain.Blog;

namespace Jonty.Blog.Blog.Impl
{
    public class BlogService: JontyBlogApplicationServiceBase, IBlogService
    {
        private readonly IPostRepository _postRepository;

        public BlogService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        /// <summary>
        /// 新增文章
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<bool> InsertPostAsync(PostDto dto)
        {
           var entity = new Post()
           {
               Title = dto.Title,
               Author = dto.Author,
               Url = dto.Url,
               Html = dto.Html,
               Markdown = dto.Markdown,
               CategoryId = dto.CategoryId,
               CreationTime = dto.CreationTime
           };
           var post = await _postRepository.InsertAsync(entity);
           return post != null;
        }

        /// <summary>
        /// 删除文章
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeletePostAsync(int id)
        {
            await _postRepository.DeleteAsync(id);
            return true;
        }

        /// <summary>
        /// 修改文章
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<bool> UpdatePostAsync(int id, PostDto dto)
        {
            var post = await _postRepository.GetAsync(id);
            post.Title = dto.Title;
            post.Author = dto.Author;
            post.Url = dto.Url;
            post.Html = dto.Html;
            post.Markdown = dto.Markdown;
            post.CategoryId = dto.CategoryId;
            post.CreationTime = dto.CreationTime;

            await _postRepository.UpdateAsync(post);

            return true;
        }

        /// <summary>
        /// 获取文章
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<PostDto> GetPostAsync(int id)
        {
            var post = await _postRepository.GetAsync(id);

            return new PostDto
            {
                Title = post.Title,
                Author = post.Author,
                Url = post.Url,
                Html = post.Html,
                Markdown = post.Markdown,
                CategoryId = post.CategoryId,
                CreationTime = post.CreationTime
            };
        }
    }
}
