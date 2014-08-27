using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Selenium_demo.Helpers;
using Selenium_demo.UI.Controls;

namespace Selenium_demo.UI.Pages
{
    public class BaseForumPage : Page
    {
        public BaseForumPage(IWebDriver driver, IWebElement element) : base(driver, element)
        {
        }


        #region User actions
        public void MainSearchFor(string searchString, string searchType = null)
        {
            if (!string.IsNullOrEmpty(searchType))
                tabsMainSearchType.Select(searchType);
            txtMainSearch.SetValue(searchString);
            btnMainSearchSubmit.Click();
            Driver.WaitForPageToLoad();
        }


        public void Login(string userName, string password)
        {
            txtLogin.SetValue(userName);
            txtPassword.SetValue(password);
            btnLoginSubmit.Click();
            Driver.WaitForPageToLoad();
        }

        public void OpenMessages()
        {
            btnMessages.Click();
            Driver.WaitForPageToLoad();
        }

        public FavoritesPage OpenFavorites()
        {
            btnFavorites.Click();
            Driver.WaitForPageToLoad();

            return new FavoritesPage(Driver, Driver.FindElement(By.TagName("body")));
        }

        public MainPage Logout()
        {
            btnLogout.Click();
            Driver.WaitForPageToLoad();

            return new MainPage(Driver, Driver.FindElement(By.TagName("body")));
        }
        

        #endregion

        #region main searchbox
        protected IWebElement MainSearchElement
        {
            get { return Element.FindElement(By.CssSelector("#onliner-search")); }
        }

        public TextField txtMainSearch
        {
            get
            {
                return new TextField(Driver, MainSearchElement.FindElement(By.CssSelector("input")));
            }
        }

        public Tabs tabsMainSearchType
        {
            get { return new Tabs(Driver, MainSearchElement.FindElement(By.CssSelector("#search-choose"))); }
        }

        public Button btnMainSearchSubmit
        {
            get { return new Button(Driver, MainSearchElement.FindElement(By.CssSelector("#search-input"))); }
        }
        #endregion

        #region login form
        // visible when user is not logged in
        protected IWebElement userElement
        {
            get { return Element.FindElement(By.CssSelector(".onliner__user")); }
        }

        public TextField txtLogin
        {
            get { return new TextField(Driver, userElement.FindElement(By.Name("username"))); }
        }
        
        public TextField txtPassword
        {
            get { return new TextField(Driver, userElement.FindElement(By.Name("password"))); }
        }

        public Button btnLoginSubmit
        {
            get { return new Button(Driver, userElement.FindElement(By.CssSelector("input[type=\"submit\"]"))); }
        }

        
        #endregion

        #region user menu
        // visible when user is logged in
        public Button btnLogout
        {
            get
            {
                var btnElement = userElement.FindElements(By.CssSelector(".onliner__user__exit")).FirstOrDefault();
                return btnElement == null ? null : new Button(Driver, btnElement);
            }
        }

        public Button btnMessages
        {
            get
            {
                return new Button(Driver,
                                  userElement.FindElements(By.CssSelector(".onliner__user__bar a")).ElementAtOrDefault(0));
            }
        }

        public Button btnFavorites
        {
            get
            {
                return new Button(Driver,
                                  userElement.FindElements(By.CssSelector(".onliner__user__bar a")).ElementAtOrDefault(1));
            }
        }

        #endregion

        #region main toolbar

        #endregion

        #region forum searchbox

        #endregion
    }
}
