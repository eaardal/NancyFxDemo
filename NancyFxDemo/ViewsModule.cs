using Nancy;

namespace NancyFxDemo
{
    public class ViewsModule : NancyModule
    {
        public ViewsModule()
        {
            Get["/index"] = p => View["index.html"];
        }
    }
}
