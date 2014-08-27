using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace Selenium_demo.Helpers
{
    public class WebdriverFactory
    {
        public static IWebDriver GetDriver()
        {
            IWebDriver driver;
            if (Config.Driver.Equals("Firefox"))
            {
                driver = new FirefoxDriver(new FirefoxProfile());
            }
            else if (Config.Driver.Equals("Chrome"))
            {
                driver = new ChromeDriver();
            }
            else
            {
                driver = new InternetExplorerDriver();
            }

            //driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(Config.ImplicitlyWait));
            driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(Config.PageLoadTimeout));
            return driver;
        }
    }
}
