using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;

namespace Selenium_demo.UI.Controls
{
    public class Button : Control
    {
        public Button(IWebDriver driver, IWebElement element) : base(driver, element)
        {
        }

        public void Click()
        {
            Element.Click();
        }
    }
}
