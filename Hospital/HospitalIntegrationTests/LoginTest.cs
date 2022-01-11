using HospitalAPI.DTO;
using HospitalLibrary.MedicalRecords.Model;
using HospitalLibrary.MedicalRecords.Model.Enums;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HospitalIntegrationTests
{
    public class LoginTest : IClassFixture<InjectionFixture>
    {
        private readonly InjectionFixture injection;
        public LoginTest(InjectionFixture injection)
        {
            this.injection = injection;
        }

        [Theory]
        [MemberData(nameof(DataSuccessfully))]
        public async Task User_Login_Successfully(LoginDTO login)
        {
            // Arrange //
            var json = JsonConvert.SerializeObject(login);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var url = "api/login";

            // Act //
            var response = await injection.Client.PostAsync(url, data);

            // Assert //
            response.EnsureSuccessStatusCode();

            var resultString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<User>(resultString);

            Assert.Equal(result.Username, login.Username);
            Assert.Equal(result.Password, login.Password);
            Assert.Equal(result.UserType, login.UserType);
            Assert.True(result.Activated);

        }


        [Theory]
        [MemberData(nameof(DataUnsuccessfully))]
        public async Task User_Login_Unsuccessfully(LoginDTO login, UserType userType)
        {
            // Arrange //
            var json = JsonConvert.SerializeObject(login);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var url = "api/login";

            // Act //
            var response = await injection.Client.PostAsync(url, data);

            // Assert //
            response.StatusCode.Equals(400);

            Assert.Equal(login.UserType, userType);

        }

        public static IEnumerable<object[]> DataSuccessfully()
        {
            var retVal = new List<object[]>();

            LoginDTO login = new LoginDTO( "Monika", "pacijent123", UserType.patient );

            retVal.Add(new object[] { login });

            return retVal;
        }

        public static IEnumerable<object[]> DataUnsuccessfully()
        {
            var retVal = new List<object[]>();

            LoginDTO login = new LoginDTO("Monika", "pacijent123", UserType.director);

            var expectedUser = UserType.director;

            retVal.Add(new object[] { login, expectedUser });

            return retVal;
        }
    }

}
