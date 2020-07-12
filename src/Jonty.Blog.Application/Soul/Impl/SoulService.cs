using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jonty.Blog.Domain.Shared;
using Jonty.Blog.Domain.Soul;
using Jonty.Blog.Domain.Soul.Repositories;
using Jonty.Blog.ToolKits.Base;

namespace Jonty.Blog.Application.Soul.Impl
{
    public class SoulService:JontyBlogApplicationServiceBase, ISoulService
    {
        private readonly IChickenSoupRepository _chickenSoupRepository;

        public SoulService(IChickenSoupRepository chickenSoupRepository)
        {
            _chickenSoupRepository = chickenSoupRepository;
        }

        /// <summary>
        /// 获取鸡汤文本
        /// </summary>
        /// <returns></returns>
        public async Task<ServiceResult<string>> GetRandomChickenSoupAsync()
        {
            var result = new ServiceResult<string>();

            var chickenSoup = await _chickenSoupRepository.GetRandomAsync();

            result.IsSuccess(chickenSoup.Content);
            return result;
        }

        /// <summary>
        /// 批量插入鸡汤
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public async Task<ServiceResult<string>> BulkInsertChickenSoupAsync(IEnumerable<string> list)
        {
            var result = new ServiceResult<string>();

            if (!list.Any())
            {
                result.IsFailed(JontyBlogConsts.ResponseText.DATA_IS_NONE);
                return result;
            }

            var chickenSoups = list.Select(x => new ChickenSoup { Content = x });
            await _chickenSoupRepository.BulkInsertAsync(chickenSoups);

            result.IsSuccess(JontyBlogConsts.ResponseText.INSERT_SUCCESS);
            return result;
        }
    }
}