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
    public class MaliciousPatientsTest : IClassFixture<InjectionFixture>
    {
        private readonly InjectionFixture injection;

        public MaliciousPatientsTest(InjectionFixture injection)
        {
            this.injection = injection;
        }
        [Theory]
        [MemberData(nameof(DataBlock))]
        public async Task Block_Malicious_Patient(PatientRegistrationDTO patient)
        {
            var json = JsonConvert.SerializeObject(patient);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var url = "api/patient/block";

            var response = await injection.Client.PutAsync(url, data);

            response.EnsureSuccessStatusCode();

            var resultString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Patient>(resultString);

            Assert.True(result.Blocked);
        }
        [Fact]
        [MemberData(nameof(DataAll))]
        public async Task Get_All_Malicious_Patients()
        {
            var url = "api/patient/getMalicious";

            var response = await injection.Client.GetAsync(url);

            response.EnsureSuccessStatusCode();

            var resultString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Patient>(resultString);

            Assert.Equal("1", result.Id);

        }

        public static IEnumerable<object[]> DataBlock()
        {
            var retVal = new List<object[]>();

            Doctor doctor = new Doctor();
            doctor.Id = "1";
            List<Allergy> allergies = new List<Allergy>();

            PatientRegistrationDTO patient = new PatientRegistrationDTO("Mira", "Miric", DateTime.Now,
                "0542369712546", "Partizanskih baza 7.", "0666423599", "pacijentmira@gmail.com",
                "Mirami", "mira123", Gender.female,
                "Novi Sad", "Serbia", UserType.patient, BloodType.B, RhFactor.positive,
                189, 85, allergies, doctor.Id, "http://localhost:4200/authentication/emailconfirmation");

            retVal.Add(new object[] { patient });

            return retVal;
        }
        public static IEnumerable<object[]> DataAll()
        {
            var retVal = new List<object[]>();

            Doctor doctor = new Doctor();
            doctor.Id = "2";
            List<Allergy> allergies = new List<Allergy>();

            Patient patient = new Patient("1", "Mira", "Miric", DateTime.Now,
                "0542369712546", "Partizanskih baza 7.", "0666423599", "pacijentmira@gmail.com",
                "Mirami", "mira123", Gender.female,
                "Novi Sad", "Serbia", UserType.patient, BloodType.B, RhFactor.positive,
                189, 85, allergies, doctor, true, true);

            Patient patient2 = new Patient("2", "Mira", "Miric", DateTime.Now,
                "0542369712546", "Partizanskih baza 7.", "0666423599", "pacijentmira@gmail.com",
                "Mirami", "mira123", Gender.female,
                "Novi Sad", "Serbia", UserType.patient, BloodType.B, RhFactor.positive,
                189, 85, allergies, doctor, false, true);

            retVal.Add(new object[] { patient, patient2 });

            return retVal;
        }
    }
}
