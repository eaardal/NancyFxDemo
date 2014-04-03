using Nancy;

namespace NancyFxDemo.Modules
{
    public class HelloWorldModule : NancyModule
    {
        public HelloWorldModule()
        {
            Get["/"] = parameters => "Hello World";
        }
    }
}
