using System;
using Nancy;
using Nancy.Hosting.Self;

namespace NancyFxDemo.SelfHost
{
    internal static class Program
    {
        private const string Url = "http://localhost:8008";

        private static void Main(string[] args)
        {
            var config = new HostConfiguration {UrlReservations = new UrlReservations {CreateAutomatically = true}};
            var bootstrapper = new CustomBoot();
            using (var host = new NancyHost(new Uri(Url), bootstrapper, config))
            {
                host.Start();
                Console.WriteLine("Nancy self host started @ {0}. Press any key to exit", Url);
                Console.ReadKey();
            }
        }
    }

    public class CustomBoot : DefaultNancyBootstrapper
    {
        protected override Nancy.Diagnostics.DiagnosticsConfiguration DiagnosticsConfiguration
        {
            get { return new Nancy.Diagnostics.DiagnosticsConfiguration {Password = "123"}; }
        }
    }
}
