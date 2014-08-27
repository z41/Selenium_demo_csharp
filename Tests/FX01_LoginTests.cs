using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Selenium_demo.Helpers;
using Selenium_demo.UI.Pages;

namespace Selenium_demo.Tests
{
    public class FX01_LoginTests : TestBase
    {
        [Test]
        public void TC01_LoginCorrect()
        {
            var mainPage = new MainPage(Driver, Body);
            mainPage.Login(Config.Username, Config.Password);
            
            mainPage = new MainPage(Driver, Body);
            Expect(mainPage.btnLogout, Is.Not.Null);

            // after test
            mainPage.Logout();
        }

        [Test]
        public void TC02_LoginIncorrect()
        {
            var mainPage = new MainPage(Driver, Body);
            mainPage.Login(Config.Username, Config.Password + "habracadabra");

            var LoginPage = new LoginPage(Driver, Body);
            // we hardcoded error message here, but it is good practice to store all error string in one place (and maybe import them)
            Expect(LoginPage.ErrorMessage, Is.StringContaining("неправильные"));


            // after test
            OpenMainPage();
        }
        
        
    }
}
