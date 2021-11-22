using Hospital_library.MedicalRecords.Model;
using Hospital_library.MedicalRecords.Model.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HospitalIntegrationTests
{
    public class RegistrationTest : IClassFixture<InjectionFixture>
    {
        private readonly InjectionFixture injection;

        public RegistrationTest(InjectionFixture injection)
        {
            this.injection = injection;
        }

        [Fact]
        public async Task Checks_Successful_RegistrationAsync()
        {   /* How to call service in integration test
              var service = (PatientService) injection.ServiceProvider.GetService(typeof(PatientService));
              service.Register(new Patient());
            */

            // Arrange //
            var json = JsonConvert.SerializeObject(CreateNewPatient());
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var url = "api/registration";

            // expected result from rest service
            var expectedJMBG = "0542369712546";

            // Act //
            var response = await injection.Client.PostAsync(url, data);

            // Assert
            // This makes sure, you return a success http code back in case of 4xx status codes 
            // or exceptions (5xx codes) it throws an exception
            response.EnsureSuccessStatusCode();

            var resultString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Patient>(resultString);

            Assert.Equal(result.Jmbg, expectedJMBG);

        }

        public Patient CreateNewPatient()
        {
            Doctor doctor = new Doctor();
            doctor.Id = "1";
            List<Allergy> allergies = new List<Allergy>();

            Patient newPatient = new Patient("2", "Mira", "Miric", DateTime.Now,
                "0542369712546", "Partizanskih baza 7.", "0666423599", "marko@gmail.com",
                "Mirami", "mira123", Hospital_library.Model.Enumeration.Gender.female,
                "Novi Sad", "Serbia", UserType.patient, BloodType.B, RhFactor.positive,
                189, 85, doctor, allergies);

            return newPatient;
        }
    }
}
