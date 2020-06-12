using Volo.Abp.Settings;

namespace Jonty.Blog.Settings
{
    public class BlogSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(BlogSettings.MySetting1));
        }
    }
}
