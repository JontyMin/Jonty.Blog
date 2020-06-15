using System;
using System.Threading.Tasks;
using Jonty.Blog.ToolKits;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Jonty.Blog.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await Host.CreateDefaultBuilder(args)
                .UseLog4Net()
                .ConfigureWebHostDefaults(builder =>
                {
                    builder.UseIISIntegration()
                        .UseStartup<Startup>();
                }).UseAutofac().Build().RunAsync();
        }
    }
}
