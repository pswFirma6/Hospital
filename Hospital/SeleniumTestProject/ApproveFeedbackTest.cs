using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Selenium.Pages;
using System;
using Xunit;

namespace Selenium
{
    public class ApproveFeedbackTest
    {
        private readonly IWebDriver driver;
        private HomePage homePage;
        private LandingPage landingPage;
        private PatientFeedbacksPage patientFeedbacksPage;

        public ApproveFeedbackTest()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("start-maximized");
            options.AddArguments("disable-infobars");
            options.AddArguments("--disable-extensions");
            options.AddArguments("--disable-gpu");
            options.AddArguments("--disable-dev-shm-usage");
            options.AddArguments("--no-sandbox");
            options.AddArguments("--disable-notifications");

            driver = new ChromeDriver(options);

            landingPage = new LandingPage(driver);
            landingPage.Navigate();
            landingPage.ButtonDisplayed();
            landingPage.ClickButton();

            homePage = new HomePage(driver);
            homePage.ButtonDisplayed();
            homePage.ClickButton();
        }

        [Fact]
        public void TestApproveFeedback()
        {
            patientFeedbacksPage = new PatientFeedbacksPage(driver);
            if (patientFeedbacksPage.FeedbackCount() > 0)
            {
                patientFeedbacksPage.ApproveButonDisplayed(2);
            }
            patientFeedbacksPage.ClickApproveButton(2);
            patientFeedbacksPage.IsFeedbackApproved(2);
            patientFeedbacksPage.WithDrawClickable(2);
        }
    }
}
