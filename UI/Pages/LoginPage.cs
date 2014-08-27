using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Selenium_demo.UI.Controls;

namespace Selenium_demo.UI.Pages
{
    public class LoginPage : Page
    {
        public LoginPage(IWebDriver driver, IWebElement element) : base(driver, element)
        {
        }

        public TextField txtLogin
        {
            get { return new TextField(Driver, Element.FindElement(By.Name("username"))); }
        }

        public TextField txtPassword
        {
            get { return new TextField(Driver, Element.FindElement(By.Name("password"))); }
        }

        public Button btnLoginSubmit
        {
            get { return new Button(Driver, Element.FindElement(By.CssSelector(".btn input"))); }
        }

        public string ErrorMessage
        {
            get { return Element.FindElement(By.CssSelector(".error")).Text.Trim(); }
        }
    }
}
