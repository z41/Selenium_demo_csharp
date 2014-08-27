using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Selenium_demo.UI.Controls;

namespace Selenium_demo.UI.Forms
{
    public abstract class Form : Control
    {
        protected Form(IWebDriver driver, IWebElement element) : base(driver, element)
        {
        }
    }
}
