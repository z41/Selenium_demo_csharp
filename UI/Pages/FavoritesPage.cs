using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Selenium_demo.Helpers;
using OpenQA.Selenium;
using Selenium_demo.UI.Controls;

namespace Selenium_demo.UI.Pages
{
    public class FavoritesPage : BaseForumPage
    {
        public FavoritesPage(IWebDriver driver, IWebElement element) : base(driver, element)
        {
        }

        #region User actions
        public FavoritesPage SelectFavType(string favType)
        {
            tabsFavoriteTabs.Select(favType);
            Driver.WaitForPageToLoad();
            return new FavoritesPage(Driver, Driver.FindElement(By.TagName("body")));
        }
        #endregion

        public AdsTable AdsTable
        {
            get { return new AdsTable(Driver, Element.FindElement(By.CssSelector("#bookmarksList"))); }
        }

        public Tabs tabsFavoriteTabs
        {
            get
            {
                return new Tabs(Driver, Element.FindElement(By.CssSelector(".b-hdtopic ul")));
            }
        }
    }

    public class AdsTable : Table
    {
        public AdsTable(IWebDriver driver, IWebElement element)
            : base(driver, element)
        {
        }

        public Tabs tabsFilter
        {
            get { return new Tabs(Driver, rowsElements.First().FindElement(By.CssSelector("ul"))); }
        }

        public IEnumerable<AdsTableRow> AdsTableRows
        {
            get
            {
                var rElements = rowsElements;
                // there many nuances for ads tables (too many different selectors). So we have a little trick there
                return rElements.Select(rElement => new AdsTableRow(Driver, rElement)).Where(row => row.AdsLink!=null);
            }
        }
    }

    public class AdsTableRow : TableRow
    {
        public AdsTableRow(IWebDriver driver, IWebElement element)
            : base(driver, element)
        {
        }

        // actually we have many nested table here and difficult layout, but I don't want to complicate
        public Link AdsLink
        {
            get
            {
                var linkElement = Element.FindElements(By.CssSelector(".wraptxt a")).FirstOrDefault();
                return linkElement == null ? null : new Link(Driver, linkElement);
            }
        }

    }
}
