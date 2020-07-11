using Jonty.Blog.Domain.Configurations;
using Volo.Abp.Data;

namespace Jonty.Blog.EntityFrameworkCore
{
    public class JontyBlogConnectionStringAttribute : ConnectionStringNameAttribute
    {
        private static readonly string db = AppSettings.EnableDb;

        public JontyBlogConnectionStringAttribute(string name = "") : base(db)
        {
            Name = string.IsNullOrEmpty(name) ? db : name;
        }

        public new string Name { get; }
    }
}