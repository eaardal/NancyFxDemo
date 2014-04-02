using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using Nancy;

namespace NancyFxDemo
{
    public class CustomersModule : NancyModule
    {
        private readonly List<string> _customers = new List<string> { "John", "Jack", "Sarah", "Bill", "Michele" }; 

        public CustomersModule() : base("/customers")
        {
            //SetUpBeforeAfterHandling();
            CreateRoutes();
        }

        private void CreateRoutes()
        {
            Get["/"] = parameters => base.Response.AsJson(_customers);

            // Nullable param: {name?}
            // Default value: {name:<default value>}
            Get["/{name}"] = parameters => "Hello " + parameters.name;

            Get["/{name}/{age:min(18)}"] = parameters => "Hi " + parameters.name + " you are " + parameters.age + " years old.";
        }

        private void SetUpBeforeAfterHandling()
        {
            base.Before.AddItemToEndOfPipeline(context =>
                                               {
                                                   // Do some before stuff...
                                                   return context.Response;
                                               });

            base.After.AddItemToEndOfPipeline(context =>
                                              {
                                                  // Do some after stuff...
                                              });
        }
    }
}
