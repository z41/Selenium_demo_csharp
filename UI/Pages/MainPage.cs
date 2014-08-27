using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Selenium_demo.UI.Controls;

namespace Selenium_demo.UI.Pages
{
    public class MainPage : BaseForumPage
    {
        public MainPage(IWebDriver driver, IWebElement element) : base(driver, element)
        {
        }
        
        #region forum list
        public IEnumerable<string> Categories()
        {
            return Element.FindElements(By.CssSelector(".b-columntopic h3")).Select(el => el.Text);
        }
        public IEnumerable<Link> GetLinksForCategory(string categoryName)
        {
            var categoryElement = Element.FindElements(By.CssSelector(".cm-onecat")).FirstOrDefault(
                cat =>
                cat.FindElements(By.CssSelector(".b-columntopic h3")).Any(
                    catName => catName.Text.Trim().Equals(categoryName)));


            return categoryElement == null ? new Link[] {}
                       : categoryElement
                             .FindElements(By.CssSelector("a")).Where(el => el.Displayed).Select(
                                 linkElement => new Link(Driver, linkElement));
        }
        #endregion

        #region MyRegion

        #endregion
    }
}
