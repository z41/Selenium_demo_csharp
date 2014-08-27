using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Selenium_demo.Helpers
{
    public static class Utils
    {
        public static void WaitForPageToLoad(this IWebDriver driver)
        {
            var timeout = Config.PageLoadTimeout;
            
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout))
                {
                    PollingInterval = TimeSpan.FromMilliseconds(500)
                };
                wait.Until(w =>
                {
                    var state = ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState");
                    Console.WriteLine("Current document state is {0}", state);
                    return state.Equals("complete") || state.Equals("loaded");
                });

            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine("Page was not loaded in {0} sec", timeout);
            }
        }

        public static T GetRandomElement<T>(this IEnumerable<T> collection)
        {
            if (collection == null || !collection.Any())
                throw new Exception("Empty collection");
            return collection.ElementAt(new Random().Next(collection.Count()));
        }
        
    }
}
