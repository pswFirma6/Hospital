using Hospital_API;
using Hospital_API.ImplRepository;
using Hospital_API.ImplService;
using Hospital_library.MedicalRecords.Model;
using Hospital_library.MedicalRecords.Model.Enums;
using Hospital_library.MedicalRecords.Repository.Repository.Interface;
using Microsoft.EntityFrameworkCore;
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
        {
            //var service = (PatientService) injection.ServiceProvider.GetService(typeof(PatientService));
            //service.Register(new Patient());
            
            var url = "api/registration";

            Doctor doctor = new Doctor();
            List<Allergy> allergies = new List<Allergy>();

            Patient newPatient = new Patient("2", "Mira", "Miric", DateTime.Now,
                "0542369712546", "Partizanskih baza 7.", "0666423599", "marko@gmail.com",
                "Mirami", "mira123", Hospital_library.Model.Enumeration.Gender.female,
                "Novi Sad", "Serbia", UserType.patient, BloodType.B, RhFactor.positive,
                189, 85, doctor, allergies);

            var json = JsonConvert.SerializeObject(newPatient);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await injection.Client.PostAsync(url, data);

            // expected result from rest service
            var expectedJMBG = "0542369712546";

            // Assert
            // This makes sure, you return a success http code back in case of 4xx status codes 
            // or exceptions (5xx codes) it throws an exception
            response.EnsureSuccessStatusCode();

            var resultString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Patient>(resultString);

            Assert.Equal(result.Jmbg, expectedJMBG);

        }
    }
}
