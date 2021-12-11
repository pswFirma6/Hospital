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
    public class CancelAppointmentTest : IClassFixture<InjectionFixture>
    {
        private readonly InjectionFixture injection;

        public CancelAppointmentTest(InjectionFixture injection)
        {
            this.injection = injection;
        }

        [Theory]
        [MemberData(nameof(Data))]
        public async Task Cancel_PatientAppointmentAsync(Appointment appointment )//, AppointmentState expectedState)
        {
            var json = JsonConvert.SerializeObject(appointment);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var url = "api/appointment";

            var response = await injection.Client.PutAsync(url, data);

            response.EnsureSuccessStatusCode();

            var resultString = await response.Content.ReadAsStringAsync(); // Here we get response content, Patient.
            var result = JsonConvert.DeserializeObject<Appointment>(resultString);

            //Assert.Equal(result.State , expectedState);

        }


        public static IEnumerable<object[]> Data()
        {
            var retVal = new List<object[]>();
            //Kreiramo appointment koji zelimo da prosledimo
            //Kreiramo expectedState = cancelled;
           
            return retVal;
        }
    }
}
