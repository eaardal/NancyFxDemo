using Nancy;

namespace NancyFxDemo
{
    public class HelloWorldModule : NancyModule
    {
        public HelloWorldModule()
        {
            Get["/"] = parameters => "Hello World";
        }
    }
}
