using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nancy;
using Nancy.Testing;

namespace NancyFxDemo.Tests
{
    [TestClass]
    public class ModuleTests
    {
        [TestMethod]
        public void GetOrdersRoot_ShouldReturnStatusCodeOK()
        {
            var browser = new Browser(with => with.Module<OrdersModule>());

            BrowserResponse result = browser.Get("/orders", with =>
                                                      {
                                                          with.HttpRequest();
                                                      });

            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
        }

        [TestMethod]
        public void PostLogin_WhenUsernameNotExist_ShouldReturnStatusCodeSeeOtherAndRedirect()
        {
            const string username = "mr.unregisteredUser";
            var browser = new Browser(with => with.Module<LoginModule>());

            BrowserResponse result = browser.Post("/login/", with =>
                                                             {
                                                                 with.HttpRequest();
                                                                 with.FormValue("Username", username);
                                                             });

            Assert.AreEqual(HttpStatusCode.SeeOther, result.StatusCode);
            result.ShouldHaveRedirectedTo("/login/unauthorized");
        }

        [TestMethod]
        public void GetIndexView_ShouldHaveWelcomeText()
        {
            var browser = new Browser(with => with.Module<ViewsModule>());
            
            BrowserResponse result = browser.Get("/index", with => with.HttpRequest());

            result.Body["#welcome_msg"]
                .ShouldExistOnce()
                .And.ShouldBeOfClass("my_header")
                .And.ShouldContain("Welcome");
        }
    }
}
