using Nancy;

namespace NancyFxDemo.Modules
{
    public class ViewsModule : NancyModule
    {
        public ViewsModule()
        {
            Get["/index"] = p => View["index.html"];

            Get["/index2"] = p => View["indexwithmodel.html", new { Name = "John Smith", Age = 30 }];
        }
    }
}
