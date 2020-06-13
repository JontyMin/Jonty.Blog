using System.Reflection.Emit;
using Jonty.Blog.Domain;
using Jonty.Blog.Domain.Blog;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace Jonty.Blog
{
    public static class JontyBlogDbContextModelCreatingExtensions
    {
        public static void Configure(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            builder.Entity<Post>(options =>
            {
                options.ToTable(JontyBlogConsts.DbTablePrefix + JontyBlogDbConsts.DbTableName.Posts);
                options.HasKey(x => x.Id);
                options.Property(x => x.Title).HasMaxLength(200).IsRequired();
                options.Property(x => x.Author).HasMaxLength(10);
                options.Property(x => x.Url).HasMaxLength(100).IsRequired();
                options.Property(x => x.Html).HasColumnType("longtext").IsRequired();
                options.Property(x => x.Markdown).HasColumnType("longtext").IsRequired();
                options.Property(x => x.CategoryId).HasColumnType("int");
                options.Property(x => x.CreationTime).HasColumnType("datetime");
            });

            builder.Entity<Category>(options =>
            {
                options.ToTable(JontyBlogConsts.DbTablePrefix + JontyBlogDbConsts.DbTableName.Categories);
                options.HasKey(x => x.Id);
                options.Property(x => x.CategoryName).HasMaxLength(50).IsRequired();
                options.Property(x => x.DisplayName).HasMaxLength(50).IsRequired();
            });

            builder.Entity<Tag>(options =>
            {
                options.ToTable(JontyBlogConsts.DbTablePrefix + JontyBlogDbConsts.DbTableName.Tags);
                options.HasKey(x => x.Id);
                options.Property(x => x.TagName).HasMaxLength(50).IsRequired();
                options.Property(x => x.DisplayName).HasMaxLength(50).IsRequired();
            });

            builder.Entity<Tag>(options =>
            {
                options.ToTable(JontyBlogConsts.DbTablePrefix + JontyBlogDbConsts.DbTableName.Tags);
                options.HasKey(x => x.Id);
                options.Property(x => x.TagName).HasMaxLength(50).IsRequired();
                options.Property(x => x.DisplayName).HasMaxLength(50).IsRequired();
            });

            builder.Entity<PostTag>(options =>
            {
                options.ToTable(JontyBlogConsts.DbTablePrefix + JontyBlogDbConsts.DbTableName.PostTags);
                options.HasKey(x => x.Id);
                options.Property(x => x.PostId).HasColumnType("int").IsRequired();
                options.Property(x => x.TagId).HasColumnType("int").IsRequired();
            });

            builder.Entity<FriendLink>(options =>
            {
                options.ToTable(JontyBlogConsts.DbTablePrefix + JontyBlogDbConsts.DbTableName.Friendlinks);
                options.HasKey(x => x.Id);
                options.Property(x => x.Title).HasMaxLength(20).IsRequired();
                options.Property(x => x.LinkUrl).HasMaxLength(100).IsRequired();
            });
        }
    }
}