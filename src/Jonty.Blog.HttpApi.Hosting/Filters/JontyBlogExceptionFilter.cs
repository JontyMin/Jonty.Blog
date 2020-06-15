using Jonty.Blog.ToolKits.Helper;
using log4net;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Jonty.Blog.Web.Filters
{
    public class JontyBlogExceptionFilter:IExceptionFilter
    {
        private readonly ILog _log;

        public JontyBlogExceptionFilter()
        {
            _log = LogManager.GetLogger(typeof(JontyBlogExceptionFilter));
        }
        /// <summary>
        /// 异常处理
        /// </summary>
        /// <param name="context"></param>
        public void OnException(ExceptionContext context)
        {
            //// 日志记录
            //LoggerHelper.WriteToFile($"{context.HttpContext.Request.Path}|{context.Exception.Message}", context.Exception);

            // 错误日志记录
            _log.Error($"{context.HttpContext.Request.Path}|{context.Exception.Message}", context.Exception);
        }
    }
}