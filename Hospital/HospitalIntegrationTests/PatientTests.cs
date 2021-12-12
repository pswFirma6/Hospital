using HospitalAPI;
using HospitalAPI.DTO;
using HospitalLibrary.MedicalRecords.Model;
using HospitalLibrary.MedicalRecords.Model.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
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

            var url = "api/Patient/2";

            // Act //

            var response = await injection.Client.GetAsync(url);

            // Assert //
            // This makes sure, you return a success http code back in case of 4xx status codes 
            // or exceptions (5xx codes) it throws an exception

            response.EnsureSuccessStatusCode();

            var resultString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<PatientRegistrationDTO>(resultString);
            
            
            Assert.NotNull(result);
            Assert.Equal("slavko", result.Username);

        }


    }
}
