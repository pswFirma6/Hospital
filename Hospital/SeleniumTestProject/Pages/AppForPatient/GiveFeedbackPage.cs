using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTestProject.Pages.AppForPatient
{
    internal class GiveFeedbackPage
    {
        private readonly IWebDriver driver;
        public const string URI = "http://localhost:4202/patient/givefeedback";
        private IWebElement TextField => driver.FindElement(By.Id("text"));
        private IWebElement PublishFeedback => driver.FindElement(By.Id("PublishFeedback"));
        private IWebElement AnonymousFeedback => driver.FindElement(By.Id("AnonymousFeedback"));
        private IWebElement SubmitButton => driver.FindElement(By.Id("submit"));

        public const string FeedbackSuccessfulMessage = "The feedback has been added!";
        public const string FeedbackUnsuccessfulMessage = "You need to complete the form!";


        public GiveFeedbackPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public bool TextFieldDisplayed()
        {
            return TextField.Displayed;
        }

        public bool PublishFeedbackDisplayed()
        {
            return PublishFeedback.Displayed;
        }

        public bool AnonymousFeedbackDisplayed()
        {
            return AnonymousFeedback.Displayed;
        }

        public void InsertText(string text)
        {
            TextField.SendKeys(text);
        }

        public void PublishFeedbackClick()
        {
            PublishFeedback.Click();
        }

        public void AnonymousFeedbackClick()
        {
            AnonymousFeedback.Click();
        }

        public void Submit()
        {
            SubmitButton.Click();
        }

        public string GetDialogMessage()
        {
            return new WebDriverWait(driver, new TimeSpan(0, 0, 100))
                .Until(ExpectedConditions.ElementToBeClickable(By.ClassName("toast-message"))).Text;
        }

        public void Navigate() => driver.Navigate().GoToUrl(URI);

    }
}
