using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumTestProject.Pages.AppForPatient;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using Xunit;

namespace SeleniumTestProject
{
    public class CreateFeedbackTest
    {
        private readonly IWebDriver driver;
        private LoginPage loginPage;
        private LandingPage landingPage;
        private GiveFeedbackPage giveFeedbackPage;
        private HomePage homePage;
        public CreateFeedbackTest()
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
            landingPage.ClickButton();

            loginPage = new LoginPage(driver);
            loginPage.InsertUsername("Srdjan");
            loginPage.InsertPassword("srdjan12345");
            loginPage.Submit();

            homePage = new HomePage(driver);
            homePage.ButtonGiveFeedbackDisplayed();
            homePage.ClickButtonGiveFeedback();
            giveFeedbackPage = new GiveFeedbackPage(driver);
            Assert.True(giveFeedbackPage.AnonymousFeedbackDisplayed());
            Assert.True(giveFeedbackPage.PublishFeedbackDisplayed());
        }
        [Fact]
        public void TestCreateFeedback()
        {
            giveFeedbackPage.InsertText("Odlicno!");
            giveFeedbackPage.AnonymousFeedbackClick();
            giveFeedbackPage.PublishFeedbackClick();
            giveFeedbackPage.Submit();
            Assert.Equal(GiveFeedbackPage.FeedbackSuccessfulMessage, giveFeedbackPage.GetDialogMessage());
        }

        public void Dispose()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}
