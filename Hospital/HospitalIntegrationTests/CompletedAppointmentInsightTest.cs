using HospitalLibrary.MedicalRecords.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HospitalIntegrationTests
{
    public class CompletedAppointmentInsightTest : IClassFixture<InjectionFixture>
    {
        private readonly InjectionFixture injection;
        public CompletedAppointmentInsightTest(InjectionFixture injection)
        {
            this.injection = injection;
        }

        [Theory]
        [MemberData(nameof(ExpectedReportResults))]
        public async Task ExpectedResults(DateTime dateTime, string expectedDoctorName, string expectedPatientName, string expectedDoctorReport)
        {
            var url = "api/appointment/completed/3";
            var response = await injection.Client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var resultString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<Appointment>>(resultString);

            Assert.Equal(result[0].StartTime, dateTime);
            Assert.Equal(result[0].Doctor.Name, expectedDoctorName);
            Assert.Equal(result[0].Patient.Name, expectedPatientName);
            Assert.Equal(result[0].DoctorReport, expectedDoctorReport);
        }

        public static IEnumerable<object[]> ExpectedReportResults()
        {
            var retVal = new List<object[]>();

            DateTime dateTime = DateTime.Now;
            string expectedDoctorName = "Nikola";
            string expectedPatientName = "Gerogije";
            string expectedDoctorReport = "Pacijent ima temperaturu";

            retVal.Add(new object[] { dateTime, expectedDoctorName, expectedPatientName, expectedDoctorReport });
            return retVal;
        }


        [Theory]
        [MemberData(nameof(ExpectedPrescriptionResults))]
        public async Task ExpectedResultsPrescription(string medicineName, string PharmacyName, int quantity, string recommendedDose, string doctorName)
        {
            var url = "api/appointment/completed/3";
            var response = await injection.Client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var resultString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<Appointment>>(resultString);

           
            Assert.Equal(result[0].Prescription.MedicineName, medicineName);
            Assert.Equal(result[0].Prescription.PharmacyName, PharmacyName);
            Assert.Equal(result[0].Prescription.Dosage.Quantity, quantity);
            Assert.Equal(result[0].Prescription.Dosage.RecommendedDose, recommendedDose);
            Assert.Equal(result[0].Doctor.Name, doctorName);
        }

        public static IEnumerable<object[]> ExpectedPrescriptionResults()
        {
            var retVal = new List<object[]>();


            string medicineName = "Paracetamol";
            string PharmacyName = "Benu apoteka";
            int quantity = 1;
            string recommendedDose = "4";
            string doctorName = "Nikola";

            retVal.Add(new object[] { medicineName, PharmacyName, quantity, recommendedDose, doctorName });
            return retVal;
        }
    }
}
