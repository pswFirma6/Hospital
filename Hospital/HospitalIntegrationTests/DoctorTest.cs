using System.Net;
using System.Threading.Tasks;
using Xunit;


namespace HospitalIntegrationTests
{
    public class DoctorTest : IClassFixture<InjectionFixture>
    {
        private readonly InjectionFixture injection;
        public DoctorTest(InjectionFixture injection)
        {
            this.injection = injection;
        }


        [Fact]
        public async Task Doctors_With_Specialisation()
        {
            // Arrange // 
            var url = "api/doctor/Specialists/0";

            // Act //
            var response = await injection.Client.GetAsync(url);

            // Assert //
            response.EnsureSuccessStatusCode();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            
        }

    }
}
