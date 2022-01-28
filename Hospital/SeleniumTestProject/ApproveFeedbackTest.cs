using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Selenium.Pages.AppForManager;
using SeleniumTestProject.Pages.AppForManager;
using Xunit;

namespace Selenium
{
    public class ApproveFeedbackTest
    {
        private readonly IWebDriver driver;
        private HomePage homePage;
        private LandingPage landingPage;
        private PatientFeedbacksPage patientFeedbacksPage;
        private LoginPage loginPage;

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
            Assert.True(landingPage.ButtonDisplayed());
            landingPage.ClickButton();

            loginPage = new LoginPage(driver);
            Assert.True(loginPage.ButtonDisplayed());
            loginPage.InsertUsername("markomanager");
            loginPage.InsertPassword("jasammanager");
            loginPage.ClickLogInButton();

            homePage = new HomePage(driver);
            Assert.True(homePage.ButtonDisplayed());
            homePage.ClickButton();
        }

        [Fact]
        public void TestApproveFeedbackSuccessfully()
        {
            patientFeedbacksPage = new PatientFeedbacksPage(driver);
            if (patientFeedbacksPage.FeedbackCount() > 0)
            {
                patientFeedbacksPage.ApproveButonDisplayed(2);
            }
            patientFeedbacksPage.ClickApproveButton(2);
            Assert.Equal("approved", patientFeedbacksPage.IsFeedbackApproved(2,"approved"));
            Assert.True(patientFeedbacksPage.WithDrawClickable(2));
        }

        [Fact]
        public void TestApproveFeedbackUnsuccessfully()
        {
            patientFeedbacksPage = new PatientFeedbacksPage(driver);
            if (patientFeedbacksPage.FeedbackCount() > 0)
            {
                patientFeedbacksPage.ApproveButonDisplayed(2);
            }
            patientFeedbacksPage.ClickRejectButton(3);
            Assert.Equal("rejected", patientFeedbacksPage.IsFeedbackApproved(3,"rejected"));
            Assert.True(patientFeedbacksPage.WithDrawClickable(3));
        }

        [Fact]
        public void ClickWithDrawUnsuccessfully()
        {
            patientFeedbacksPage = new PatientFeedbacksPage(driver);
            if (patientFeedbacksPage.FeedbackCount() > 0)
            {
                patientFeedbacksPage.ApproveButonDisplayed(2);
            }

            Assert.False(patientFeedbacksPage.WithDrawClickable(3));
        }

        public void Dispose()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}
