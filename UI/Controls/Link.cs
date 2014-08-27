using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using OpenQA.Selenium;

namespace Selenium_demo.UI.Controls
{
    public class Link : Control
    {
        public Link(IWebDriver driver, IWebElement element) : base(driver, element)
        {
        }

        public void Click()
        {
            SrollToElement();
            Element.Click();
        }

        public string Anchor
        {
            get { return Element.Text.Trim(); }
        }

        public string Href
        {
            get { return HttpUtility.HtmlDecode(Element.GetAttribute("href")); }
        }

        protected void SrollToElement()
        {
            try
            {
                var id = Element.GetAttribute("id");
                ((IJavaScriptExecutor)Driver).ExecuteScript(string.Format("document.getElementById('{0}').scrollIntoView(true)", id));

            }
            catch(Exception ex)
            {
                Console.WriteLine("Cannot scroll to element");
            }
        }
        
    }
}
