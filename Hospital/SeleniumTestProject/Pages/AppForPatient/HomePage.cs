using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTestProject.Pages.AppForPatient
{
    internal class HomePage
    {
        private readonly IWebDriver driver;
        public const string URI = "http://localhost:4202/patient/medicalrecords";
        //private IWebElement PatientFeedbacks => driver.FindElement(By.XPath("/html/body/app-root/app-home-page-layout/div/div[1]/div/sidebar/div/ul/li[2]"));
        private IWebElement GiveFeedback;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void ButtonGiveFeedbackDisplayed()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 20));
            wait.Until(x => x.FindElement(By.XPath("/html/body/app-root/app-homepage-layout/div/div[1]/app-sidebar/div/ul/li[1]")));
        }

        public void ClickButtonGiveFeedback()
        {
            GiveFeedback = driver.FindElement(By.XPath("/html/body/app-root/app-homepage-layout/div/div[1]/app-sidebar/div/ul/li[1]"));
            GiveFeedback.Click();
        }

        //public void Navigate() => driver.Navigate().GoToUrl(URI);
    }
}
