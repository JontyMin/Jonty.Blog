using System.Collections.Generic;
using Jonty.Blog.Domain.Shared.Enum;

namespace Jonty.Blog.Application.Contracts.Wallpaper.Params
{
    public class BulkInsertWallpaperInput
    {
        /// <summary>
        /// 类型
        /// </summary>
        public WallpaperEnum Type { get; set; }

        /// <summary>
        /// 壁纸列表
        /// </summary>
        public IEnumerable<WallpaperDto> Wallpapers { get; set; }
    }
}