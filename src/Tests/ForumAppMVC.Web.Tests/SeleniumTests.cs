﻿using ForumAppMVC.Web;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using Xunit;

namespace ForumAppMvc.Web.Tests
{
    public class SeleniumTests : IClassFixture<SeleniumServerFactory<Program>>
    {
        private readonly SeleniumServerFactory<Program> server;
        private readonly IWebDriver browser;

        // Be sure that selenium-server-standalone-3.141.59.jar is running
        public SeleniumTests(SeleniumServerFactory<Program> server)
        {
            this.server = server;
            server.CreateClient();
            var opts = new ChromeOptions();
            opts.AddArgument("--headless"); // Optional, comment this out if you want to SEE the browser window
            opts.AddArgument("no-sandbox");
            this.browser = new RemoteWebDriver(opts);
        }

        [Fact]
        public void FooterOfThePageContainsPrivacyLink()
        {
            this.browser.Navigate().GoToUrl(this.server.RootUri);
            Assert.Contains(
                this.browser.FindElements(By.CssSelector("footer a")),
                x => x.GetAttribute("href").EndsWith("/Home/Privacy"));
        }
    }
}
