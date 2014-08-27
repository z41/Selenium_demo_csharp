using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;

namespace Selenium_demo.UI.Controls
{
    public class Tabs : Control
    {
        public Tabs(IWebDriver driver, IWebElement element) : base(driver, element)
        {
        }

        protected IEnumerable<IWebElement> tabElements
        {
            get { return Element.FindElements(By.CssSelector("li a")); }
        }

        public IEnumerable<string> TabNames
        {
            get { return tabElements.Select(tab => tab.Text.Trim()); }
        }

        public void Select(string tabName)
        {
            var tabToSelect = tabElements.FirstOrDefault(tab => tab.Text.Trim().Equals(tabName));
            if (tabToSelect == null)
                throw new Exception(string.Format("No tab \"{0}\" found", tabName));
            tabToSelect.Click();
        }
    }
}
