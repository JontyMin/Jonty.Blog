namespace Jonty.Blog.Domain.Shared
{
    public class JontyBlogDbConsts
    {
        public static class DbTableName
        {
            /// <summary>
            /// 文章表
            /// </summary>
            public const string Posts = "Posts";
            /// <summary>
            /// 分类表
            /// </summary>
            public const string Categories = "Categories";
            /// <summary>
            /// 标签表
            /// </summary>
            public const string Tags = "Tags";
            /// <summary>
            /// 文章标签 一对多
            /// </summary>
            public const string PostTags = "Post_Tags";
            /// <summary>
            /// 友链表
            /// </summary>
            public const string Friendlinks = "Friendlinks";
            /// <summary>
            /// 壁纸表
            /// </summary>
            public const string Wallpapers = "Wallpapers";
            /// <summary>
            /// 热点表
            /// </summary>
            public const string HotNews = "HotNews";
            /// <summary>
            /// 鸡汤
            /// </summary>
            public const string ChickenSoups = "ChickenSoups";
        }
    }
}