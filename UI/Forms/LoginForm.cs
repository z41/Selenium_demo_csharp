using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Selenium_demo.UI.Controls;
using OpenQA.Selenium;

namespace Selenium_demo.UI.Forms
{
    public class LoginForm : Form
    {
        public LoginForm(IWebDriver driver, IWebElement element) : base(driver, element)
        {
        }

        
    }
}
