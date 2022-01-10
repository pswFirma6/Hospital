using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTestProject.Pages.AppForPatient
{
    class LandingPage
    {
        private readonly IWebDriver driver;
        public const string URI = "http://localhost:4202/landingpage";
        private IWebElement LogIn => driver.FindElement(By.Id("1"));

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
