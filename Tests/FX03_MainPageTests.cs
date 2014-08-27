using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Selenium_demo.Helpers;
using Selenium_demo.UI.Pages;

namespace Selenium_demo.Tests
{
    public class FX03_MainPageTests : TestBase
    {
        public override void FixtureSetup()
        {
            base.FixtureSetup();
            mainPage = Login(Config.Username, Config.Password);
        }

        private MainPage mainPage;

        public override void Teardown()
        {
            OpenMainPage();
            base.Teardown();
        }

        [Test]
        public void TC01_CheckCategory()
        {
            // it is better to store such things in file. Also we could improve this test and make it data-driven
            var expectedLinks = new[]
                                    {
                                        "Ноутбуки",
                                        "Запчасти для ноутбуков. Услуги",
                                        "Apple. Mac. iPod. iPhone. iPad",
                                        "Apple. Запчасти. Аксессуары. Услуги",
                                        "Планшеты и электронные книги",
                                        "Материнские платы. Процессоры. Оперативная память",
                                        "Видеокарты"
                                    };
            var actualLinks = mainPage.GetLinksForCategory("Ноутбуки. Компьютеры. Apple. Оргтехника").Select(link => link.Anchor);

            Expect(expectedLinks, Is.SubsetOf(actualLinks));
        }

    }
}
