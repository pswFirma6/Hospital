using HospitalLibrary.MedicalRecords.Model;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Xunit;

namespace HospitalIntegrationTests
{
    public class PatientTests : IClassFixture<InjectionFixture>
    {
        private readonly InjectionFixture injection;


        public PatientTests(InjectionFixture injection)
        {
            this.injection = injection;
        }


        [Fact]
        public async Task Get_patient_from_DBAsync()
        {
            // Arrange //

            /*

            var url = "api/getPatient";

            // Act //
            var response = await injection.Client.GetAsync(url);

            // Assert //
            // This makes sure, you return a success http code back in case of 4xx status codes 
            // or exceptions (5xx codes) it throws an exception
            response.EnsureSuccessStatusCode();

            var resultString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Patient>(resultString);

            Assert.Equal("SeekEquilibrium", result.Username);
            */
        }


    }
}
