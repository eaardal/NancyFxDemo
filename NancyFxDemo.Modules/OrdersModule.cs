using System.Collections.Generic;
using Nancy;
using Nancy.ModelBinding;

namespace NancyFxDemo.Modules
{
    public class OrdersModule : NancyModule
    {
        private static readonly ICollection<Order> Orders = CreateOrders();
        
        public OrdersModule() : base("/orders")
        {
            Get["/"] = p => Response.AsJson(Orders);

            Post["/add"] = p =>
                           {
                               Order newOrder = this.Bind<Order>();
                               Orders.Add(newOrder);
                               return 200;
                           };
        }

        private static ICollection<Order> CreateOrders()
        {
            return new List<Order>
                   {
                       new Order{ name = "Computer stuff", price = 1000.00, quantity = 5 },
                       new Order{ name = "Clothes stuff", price = 555.90, quantity = 3 },
                       new Order{ name = "Food stuff", price = 1234.55, quantity = 2 },
                       new Order{ name = "Car stuff", price = 2222.60, quantity = 7 },
                       new Order{ name = "Other stuff", price = 5533.50, quantity = 2 }
                   };
        }
    }

    internal class Order
    {
        public string name { get; set; }
        public double price { get; set; }
        public int quantity { get; set; }
    }
}
