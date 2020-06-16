namespace Jonty.Blog.Wallpaper
{
    public class WallpaperJobItem<T>
    {
        /// <summary>
        /// <see cref="Result"/>
        /// </summary>
        public T Result { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public WallpaperEnum Type { get; set; }
    }
}