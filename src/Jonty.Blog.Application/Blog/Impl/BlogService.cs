using Jonty.Blog.Application;
using Jonty.Blog.Domain.Blog.Repositories;
using System;
using System.Threading.Tasks;
using Jonty.Blog.Domain.Blog;
using Jonty.Blog.ToolKits.Base;

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
        public async Task<ServiceResult<string>> InsertPostAsync(PostDto dto)
        {
            var result = new ServiceResult<string>();
           //var entity = new Post()
           //{
           //    Title = dto.Title,
           //    Author = dto.Author,
           //    Url = dto.Url,
           //    Html = dto.Html,
           //    Markdown = dto.Markdown,
           //    CategoryId = dto.CategoryId,
           //    CreationTime = dto.CreationTime
           //};
           var entity = ObjectMapper.Map<PostDto, Post>(dto);
           var post = await _postRepository.InsertAsync(entity);
           if (post==null)
           {
               result.IsFailed("添加失败");
               return result;
           }
           result.IsSuccess("添加成功");
           return result;
        }

        /// <summary>
        /// 删除文章
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ServiceResult> DeletePostAsync(int id)
        {
            var result = new ServiceResult();
            await _postRepository.DeleteAsync(id);
            return result;
        }

        /// <summary>
        /// 修改文章
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<ServiceResult<string>> UpdatePostAsync(int id, PostDto dto)
        {
            var result = new ServiceResult<string>();

            var post = await _postRepository.GetAsync(id);
            if (post==null)
            {
                result.IsFailed("文章不存在");
                return result;
            }
            post.Title = dto.Title;
            post.Author = dto.Author;
            post.Url = dto.Url;
            post.Html = dto.Html;
            post.Markdown = dto.Markdown;
            post.CategoryId = dto.CategoryId;
            post.CreationTime = dto.CreationTime;

            await _postRepository.UpdateAsync(post);

            result.IsSuccess("更新成功");
            return result;
        }

        /// <summary>
        /// 获取文章
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ServiceResult<PostDto>> GetPostAsync(int id)
        {
            var result = new ServiceResult<PostDto>();
            var post = await _postRepository.GetAsync(id);

            if (post==null)
            {
                result.IsFailed("文章不存在");
                return result;
            }
            //var dto =  new PostDto
            //{
            //    Title = post.Title,
            //    Author = post.Author,
            //    Url = post.Url,
            //    Html = post.Html,
            //    Markdown = post.Markdown,
            //    CategoryId = post.CategoryId,
            //    CreationTime = post.CreationTime
            //};
            var dto = ObjectMapper.Map<Post, PostDto>(post);
            result.IsSuccess(dto);
            return result;
        }
    }
}
