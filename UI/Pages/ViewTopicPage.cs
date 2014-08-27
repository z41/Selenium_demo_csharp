using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Selenium_demo.UI.Controls;

namespace Selenium_demo.UI.Pages
{
    public class ViewTopicPage : BaseForumPage
    {
        public ViewTopicPage(IWebDriver driver, IWebElement element)
            : base(driver, element)
        {
        }

        public Link lnkMakeFavorite
        {
            get { return new Link(Driver, Element.FindElement(By.CssSelector(".bookmark-text a"))); }
        }
    }

    
}
