using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;

namespace Selenium_demo.UI.Controls
{
    public class TextField : Control
    {
        public TextField(IWebDriver driver, IWebElement element) : base(driver, element)
        {
        }

        public void SetValue(string value)
        {
            Element.Click();
            Element.Clear();
            Element.SendKeys(value);
        }

        public string GetValue()
        {
            return Element.Text;
        }
    }
}
