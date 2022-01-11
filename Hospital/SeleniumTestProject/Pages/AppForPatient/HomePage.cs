using OpenQA.Selenium;
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
        public const string URI = "http://localhost:4202/patient";
        private IWebElement PatientFeedbacks => driver.FindElement(By.XPath("/html/body/app-root/app-home-page-layout/div/div[1]/div/sidebar/div/ul/li[2]"));

    }
}
