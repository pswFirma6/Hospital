using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.WaitHelpers;

namespace SeleniumTestProject.Pages.AppForPatient
{
    internal class LoginPage
    {
        private readonly IWebDriver driver;
        public const string URI = "http://localhost:4201/login";
        public const string InvalidCredentialsMessage = "Username or password is incorrect!";
        public const string LoginSuccessfulMessage = "Login successful!";
        private IWebElement UsernameElement => driver.FindElement(By.Id("username"));
        private IWebElement PasswordElement => driver.FindElement(By.Id("password"));
        private IWebElement LoginBtnElement => driver.FindElement(By.Id("login"));

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public bool UsernameFieldDisplayed()
        {
            return UsernameElement.Displayed;
        }
        public bool PasswordFieldDisplayed()
        {
            return PasswordElement.Displayed;
        }

        public void InsertUsername(string username)
        {
            UsernameElement.SendKeys(username);
        }

        public void InsertPassword(string password)
        {
            PasswordElement.SendKeys(password);
        }

        public void Submit()
        {
            LoginBtnElement.Click();
        }

        public string GetDialogMessage()
        {
            return new WebDriverWait(driver, new TimeSpan(0, 0, 100))
                .Until(ExpectedConditions.ElementToBeClickable(By.ClassName("toast-message"))).Text;
        }

        public string GetTokenFromLocalStorage()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            return (String)js.ExecuteScript("return localStorage.getItem('jwt')");
        }
    }
}
