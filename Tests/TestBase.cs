using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using Selenium_demo.Helpers;
using Selenium_demo.UI.Pages;

namespace Selenium_demo.Tests
{
    [TestFixture]
    public class TestBase : AssertionHelper
    {
        protected IWebDriver Driver;
        protected IWebElement Body
        {
            get { return Driver.FindElement(By.TagName("body")); }
        }

        [TestFixtureSetUp]
        public virtual void FixtureSetup()
        {
            Driver = WebdriverFactory.GetDriver();
            OpenMainPage();
        }

        [TestFixtureTearDown]
        public virtual void FixtureTearDown()
        {
            Driver.Quit();
        }

        [SetUp]
        public virtual void Setup()
        {
            
        }

        [TearDown]
        public virtual void Teardown()
        {
            
        }

        public MainPage OpenMainPage()
        {
            Driver.Url = Config.MainPageUrl;
            Driver.WaitForPageToLoad();

            return new MainPage(Driver, Body);
        }

        public MainPage Login(string username, string password)
        {
            new MainPage(Driver, Body).Login(username, password);
            
            return new MainPage(Driver, Body);
        }


    }
}
