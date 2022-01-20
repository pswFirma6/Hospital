using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.Pages.AppForManager
{
    internal class LandingPage
    {
        private readonly IWebDriver driver;
        public const string URI = "http://localhost:4201/";

        private IWebElement LogIn => driver.FindElement(By.XPath("/html/body/app-root/app-landingpage-layout/div/app-navigation-bar/nav/ul/li/a"));

        public bool ButtonDisplayed()
        {
            return LogIn.Displayed;
        }

        public void ClickButton()
        {
            LogIn.Click();
        }

        public LandingPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void Navigate() => driver.Navigate().GoToUrl(URI);
    }
}
