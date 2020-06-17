namespace Jonty.Blog.Application.HelloWorld.Impl
{
    public class HelloWorldService:JontyBlogApplicationServiceBase,IHelloWorldService
    {
        public string HelloWorld()
        {
            return "hello world";
        }
    }
}