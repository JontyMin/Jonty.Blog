﻿namespace Jonty.Blog.Domain.Shared
{
    /// <summary>
    /// 全局常量
    /// </summary>
    public class JontyBlogConsts
    {
        /// <summary>
        /// 数据库前缀
        /// </summary>
        public const string DbTablePrefix = "jonty_";

        /// <summary>
        /// 语音合成欢迎词大志非才不就，大才非学不成
        /// </summary>
        public const string GreetWord = "What I cannot create,I do not understand";
        /// <summary>
        /// 缓存过期时间策略
        /// </summary>
        public static class CacheStrategy
        {
            /// <summary>
            /// 一天过期24小时
            /// </summary>

            public const int ONE_DAY = 1440;

            /// <summary>
            /// 12小时过期
            /// </summary>

            public const int HALF_DAY = 720;

            /// <summary>
            /// 8小时过期
            /// </summary>

            public const int EIGHT_HOURS = 480;

            /// <summary>
            /// 5小时过期
            /// </summary>

            public const int FIVE_HOURS = 300;

            /// <summary>
            /// 3小时过期
            /// </summary>

            public const int THREE_HOURS = 180;

            /// <summary>
            /// 2小时过期
            /// </summary>

            public const int TWO_HOURS = 120;

            /// <summary>
            /// 1小时过期
            /// </summary>

            public const int ONE_HOURS = 60;

            /// <summary>
            /// 半小时过期
            /// </summary>

            public const int HALF_HOURS = 30;

            /// <summary>
            /// 5分钟过期
            /// </summary>
            public const int FIVE_MINUTES = 5;

            /// <summary>
            /// 1分钟过期
            /// </summary>
            public const int ONE_MINUTE = 1;

            /// <summary>
            /// 永不过期
            /// </summary>

            public const int NEVER = -1;
        }

        /// <summary>
        /// 缓存前缀
        /// </summary>
        public static class CachePrefix
        {
            public const string Authorize = "Authorize";

            public const string Blog = "Blog";

            public const string Blog_Post = Blog + ":Post";

            public const string Blog_Tag = Blog + ":Tag";

            public const string Blog_Category = Blog + ":Category";

            public const string Blog_FriendLink = Blog + ":FriendLink";
        }
        /// <summary>
        /// 响应文本
        /// </summary>
        public static class ResponseText
        {
            /// <summary>
            /// 新增成功
            /// </summary>
            public const string INSERT_SUCCESS = "新增成功";

            /// <summary>
            /// 更新成功
            /// </summary>
            public const string UPDATE_SUCCESS = "更新成功";

            /// <summary>
            /// 删除成功
            /// </summary>
            public const string DELETE_SUCCESS = "删除成功";

            /// <summary>
            /// 什么不存在
            /// </summary>
            public const string WHAT_NOT_EXIST = "{0}:{1} 不存在";

            /// <summary>
            /// 数据为空
            /// </summary>
            public const string DATA_IS_NONE = "数据为空";

            /// <summary>
            /// IP地址格式错误
            /// </summary>
            public const string IP_IS_WRONG = "IP地址格式错误";

            /// <summary>
            /// 图片错误
            /// </summary>
            public const string IMG_IS_WRONG = "图片错误";

            /// <summary>
            /// 密码错误
            /// </summary>
            public const string PASSWORD_WRONG = "密码错误";

            /// <summary>
            /// 参数错误
            /// </summary>
            public const string PARAMETER_ERROR = "参数错误";
        }
    }
}