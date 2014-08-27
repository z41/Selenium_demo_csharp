using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;

namespace Selenium_demo.UI.Controls
{
    public class Table : Control
    {
        public Table(IWebDriver driver, IWebElement element) : base(driver, element)
        {
        }

        protected IEnumerable<IWebElement> rowsElements
        {
            get { return Element.FindElements(By.CssSelector("tr")); }
        }
//
//        public IEnumerable<TableRow> TableRows()
//        {
//            
//        }
    }
}
