using System.Threading.Tasks;

namespace Jonty.Blog.Data
{
    public interface IBlogDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
