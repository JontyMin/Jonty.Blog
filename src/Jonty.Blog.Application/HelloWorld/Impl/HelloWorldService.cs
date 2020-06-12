using Jonty.Blog.Application;
using Jonty.Blog.Application.HelloWorld;

namespace Jonty.Blog.HelloWorld.Impl
{
    public class HelloWorldService:JontyBlogApplicationServiceBase,IHelloWorldService
    {
        public string HelloWorld()
        {
            return "hello world";
        }
    }
}