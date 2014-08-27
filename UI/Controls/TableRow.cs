using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;

namespace Selenium_demo.UI.Controls
{
    public class TableRow : Control
    {
        public TableRow(IWebDriver driver, IWebElement element) : base(driver, element)
        {
        }

        protected IEnumerable<IWebElement> cellsElements
        {
            get { return Element.FindElements(By.CssSelector("td")); }
        }

        
    }
}
