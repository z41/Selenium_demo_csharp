using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;

namespace Selenium_demo.UI.Controls
{
    public abstract class Control
    {
        public Control(IWebDriver driver, IWebElement element)
        {
            Driver = driver;
            Element = element;
        }

        public IWebDriver Driver;
        public IWebElement Element;
    }
}
