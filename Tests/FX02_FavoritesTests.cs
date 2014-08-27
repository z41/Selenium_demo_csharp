using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Selenium_demo.Helpers;
using Selenium_demo.UI.Pages;

namespace Selenium_demo.Tests
{
    public class FX02_FavoritesTests : TestBase
    {
        public override void FixtureSetup()
        {
            base.FixtureSetup();
            mainPage = Login(Config.Username, Config.Password);
        }

        public override void Teardown()
        {
            OpenMainPage();
            base.Teardown();
        }

        private MainPage mainPage;

        [Test]
        public void TC01_FavoriteCreate()
        {
            // using of random data is not good idea for all cases! Just for demonstration
            // for example - test could fail, if category is Автозапчасти, etc
            var randomCategory = mainPage.Categories().GetRandomElement();

            var link = mainPage.GetLinksForCategory(randomCategory).FirstOrDefault();
            link.Click();
            Driver.WaitForPageToLoad();

            var forumPage = new ViewForumPage(Driver, Body);
            var adsLink = forumPage.AdsTable.AdsTableRows.GetRandomElement().AdsLink;
            var adsLinkAnchor = adsLink.Anchor;


            adsLink.Click();
            Driver.WaitForPageToLoad();

            var topicPage = new ViewTopicPage(Driver, Body);
            var favLink = topicPage.lnkMakeFavorite;
            

            Expect(favLink.Anchor.Equals("Добавить в закладки"));
            favLink.Click();

            Expect(favLink.Anchor.Equals("Удалить закладку"));
            
            var favPage = topicPage.OpenFavorites();
            favPage = favPage.SelectFavType("Барахолка");
            Expect(favPage.AdsTable.AdsTableRows.Select(row => row.AdsLink.Anchor).Contains(adsLinkAnchor));

        }
        
        
    }
}
