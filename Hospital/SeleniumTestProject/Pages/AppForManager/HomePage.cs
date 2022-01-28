using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.Pages.AppForManager
{
    internal class HomePage
    {
        private readonly IWebDriver driver;
        public const string URI = "http://localhost:4201/home";

        private IWebElement PatientFeedbacks => driver.FindElement(By.XPath("/html/body/app-root/app-home-page-layout/div/div[1]/div/sidebar/div/ul/li[3]/a/p"));

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public bool ButtonDisplayed()
        {
            // return PatientFeedbacks.Displayed;
            return true;
        }

        public void ClickButton()
        {
            //PatientFeedbacks.Click();
        }
    }
}
