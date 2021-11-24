using HospitalAPI.DTO;
using HospitalLibrary.MedicalRecords.Model;
using HospitalLibrary.MedicalRecords.Model.Enums;
using HospitalLibrary.Model.Enums;
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

        [Theory]
        [MemberData(nameof(Data))]
        public async Task Checks_Successful_RegistrationAsync(PatientRegistrationDTO newPatient, string expectedJMBG)
        {  

            // Arrange //
            var json = JsonConvert.SerializeObject(newPatient);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var url = "api/registration";


            // Act //
            var response = await injection.Client.PostAsync(url, data); // We use async beacuse http is async ( don't wait for response )

            // Assert //
            // This makes sure, you return a success http code back in case of 4xx status codes 
            // or exceptions (5xx codes) it throws an exception
            response.EnsureSuccessStatusCode();

            var resultString = await response.Content.ReadAsStringAsync(); // Here we get response content, Patient.
            var result = JsonConvert.DeserializeObject<Patient>(resultString); // Convert to json

            Assert.Equal(result.Jmbg, expectedJMBG);

        }
        public static IEnumerable<object[]> Data() 
        {
            var retVal = new List<object[]>();

            Doctor doctor = new Doctor();
            doctor.Id = "1";
            List<Allergy> allergies = new List<Allergy>();

            PatientRegistrationDTO newPatient = new PatientRegistrationDTO("Mira", "Miric", DateTime.Now,
                "0542369712546", "Partizanskih baza 7.", "0666423599", "pacijentmira@gmail.com",
                "Mirami", "mira123", Gender.female,
                "Novi Sad", "Serbia", UserType.patient, BloodType.B, RhFactor.positive,
                189, 85, allergies, doctor, "http://localhost:4200/authentication/emailconfirmation");

            // expected result from rest service
            var expectedJMBG = "0542369712546";

            retVal.Add(new object[] { newPatient, expectedJMBG });

            return retVal;
        }

    }
}
