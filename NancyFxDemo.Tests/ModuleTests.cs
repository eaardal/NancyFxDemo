using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nancy;
using Nancy.Testing;
using NancyFxDemo.Modules;

namespace NancyFxDemo.Tests
{
    [TestClass]
    public class ModuleTests
    {
        [TestMethod]
        public void GetOrdersRoot_ShouldReturnStatusCodeOK()
        {
            var browser = new Browser(with => with.Module<OrdersModule>());
            
            BrowserResponse response = browser.Get("/orders", with => with.HttpRequest());

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public void PostLogin_WhenUsernameNotExist_ShouldReturnStatusCodeSeeOtherAndRedirect()
        {
            const string username = "mr.unregisteredUser";
            var browser = new Browser(with => with.Module<LoginModule>());

            BrowserResponse response = browser.Post("/login", with =>
                                                             {
                                                                 with.HttpRequest();
                                                                 with.FormValue("Username", username);
                                                             });

            Assert.AreEqual(HttpStatusCode.SeeOther, response.StatusCode);
            response.ShouldHaveRedirectedTo("/login/unauthorized");
        }

        [TestMethod]
        public void GetIndexView_ShouldHaveWelcomeText()
        {
            var browser = new Browser(with => with.Module<ViewsModule>());
            
            BrowserResponse response = browser.Get("/index", with => with.HttpRequest());

            response.Body["#welcome_msg"]
                    .ShouldExistOnce()
                    .And.ShouldBeOfClass("my_header")
                    .And.ShouldContain("Welcome");
        } 
    }
}
