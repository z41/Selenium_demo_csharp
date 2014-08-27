using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;

namespace Selenium_demo.UI.Controls
{
    public class CheckBox : Control
    {
        public CheckBox(IWebDriver driver, IWebElement element) : base(driver, element)
        {
        }

        public bool IsChecked
        {
            get { return !string.IsNullOrEmpty(Element.GetAttribute("checked")); }
        }

        public void Check()
        {
            if (!IsChecked)
                Element.Click();
        }

        public void UnCheck()
        {
            if (IsChecked)
                Element.Click();
        }


    }
}
