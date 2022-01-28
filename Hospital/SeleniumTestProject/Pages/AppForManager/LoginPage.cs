using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTestProject.Pages.AppForManager
{
    internal class LoginPage
    {

        private readonly IWebDriver driver;

        private IWebElement UserName => driver.FindElement(By.Id("username"));
        private IWebElement Passwrod => driver.FindElement(By.XPath("/html/body/app-root/app-login/div[2]/div/div/form/div[2]/input"));

        private IWebElement LogInButton => driver.FindElement(By.XPath("/html/body/app-root/app-login/div[2]/div/div/form/button"));

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public bool ButtonDisplayed()
        {
            return LogInButton.Displayed;
        }

        public void ClickLogInButton()
        {
            LogInButton.Click();
        }

        public void InsertUsername(string username)
        {
            UserName.SendKeys(username);
        }

        public void InsertPassword(string password)
        {
            Passwrod.SendKeys(password);
        }
    }
}
