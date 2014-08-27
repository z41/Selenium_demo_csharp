using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;

namespace Selenium_demo.UI.Controls
{
    public class TableCell : Control
    {
        public TableCell(IWebDriver driver, IWebElement element) : base(driver, element)
        {
        }
    }
}
