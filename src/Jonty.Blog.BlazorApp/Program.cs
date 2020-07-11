using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Jonty.Blog.BlazorApp.Commons;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Jonty.Blog.BlazorApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");
            
            //var baseAddress = "https://api.jonty.top";
            var baseAddress = "https://localhost:44335/";

            builder.Services.AddTransient(sp => new HttpClient
            {
                BaseAddress = new Uri(baseAddress)
            });

            builder.Services.AddSingleton(typeof(Common));


            await builder.Build().RunAsync();
        }
    }
}
