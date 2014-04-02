using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.Hosting.Self;
using Nancy.TinyIoc;

namespace NancyFxDemo.SelfHost
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var config = new HostConfiguration {UrlReservations = new UrlReservations {CreateAutomatically = true}};
            var bootstrapper = new DefaultNancyBootstrapper();
            using (var host = new NancyHost(new Uri("http://localhost:8008"), bootstrapper, config))
            {
                host.Start();
                Console.WriteLine("Nancy self host started.");
                Console.ReadLine();
            }
        }
    }
}
