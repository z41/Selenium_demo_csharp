using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Selenium_demo.Helpers;
using Selenium_demo.UI.Controls;

namespace Selenium_demo.UI.Pages
{
    public abstract class Page : Control
    {
        protected Page(IWebDriver driver, IWebElement element) : base(driver, element)
        {
        }
    }
}
