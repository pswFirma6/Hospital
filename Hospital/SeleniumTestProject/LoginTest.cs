using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumTestProject.Pages.AppForPatient;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using Xunit;

namespace SeleniumTestProject
{
    public class LoginTest
    {
        private readonly IWebDriver driver;
        private LoginPage loginPage;
        private LandingPage landingPage;
        private PatientMedicalRecordPage patientMedicalRecordPage;

        public LoginTest()
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
            Assert.Equal(driver.Url, LandingPage.URI);

            Assert.True(landingPage.ButtonDisplayed());
            landingPage.ClickButton();

            loginPage = new LoginPage(driver);
            Assert.True(loginPage.UsernameFieldDisplayed());
            Assert.True(loginPage.PasswordFieldDisplayed());

        }
        [Fact]
        public void TestLogInSuccessful()
        {
            loginPage.InsertUsername("MiraMiric");
            loginPage.InsertPassword("Mira1234");
            loginPage.Submit();

            Assert.Equal(LoginPage.LoginSuccessfulMessage, loginPage.GetDialogMessage());

            var token = loginPage.GetTokenFromLocalStorage();
            Assert.NotNull(token);

            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(token);
            var tokenUsername = jwtSecurityToken.Claims.First(claim => claim.Type == JwtRegisteredClaimNames.Sub).Value;
            Assert.Equal("MiraMiric", tokenUsername);

            patientMedicalRecordPage = new PatientMedicalRecordPage(driver);
            Assert.Equal(driver.Url, PatientMedicalRecordPage.URI);
        }

        public void Dispose()
        {
            driver.Quit();
            driver.Dispose();
        }
    }


}
