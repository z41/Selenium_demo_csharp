using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;

namespace Selenium_demo.UI.Pages
{
    public class ViewForumPage : BaseForumPage
    {
        public ViewForumPage(IWebDriver driver, IWebElement element) : base(driver, element)
        {

        }

        public AdsTable AdsTable
        {
            get { return new AdsTable(Driver, Element.FindElement(By.CssSelector(".ba-tbl-list__table"))); }
        }

    }
}
