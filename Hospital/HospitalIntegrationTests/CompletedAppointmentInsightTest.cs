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
        [MemberData(nameof(ExpectedReportPrescriptionResults))]
        public async Task ExpectedResults(string expectedDoctorReport, string expectedMedicine, string expectedDose)
        {
            var url = "api/appointment/completed/3";
            var response = await injection.Client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var resultString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<Appointment>>(resultString);

            Assert.Equal(result[0].DoctorReport, expectedDoctorReport);
            Assert.Equal(result[0].Prescription.MedicineName, expectedMedicine);
            Assert.Equal(result[0].Prescription.Dosage.RecommendedDose, expectedDose);
        }

        public static IEnumerable<object[]> ExpectedReportPrescriptionResults()
        {
            var retVal = new List<object[]>();

            string expectedDoctorReport = "Pacijent ima temperaturu";
            string expectedMedicine = "Antibiotik";
            string expectedDose = "2 tablete na dan";

            retVal.Add(new object[] { expectedDoctorReport, expectedMedicine, expectedDose });
            return retVal;
        }
    }
}
