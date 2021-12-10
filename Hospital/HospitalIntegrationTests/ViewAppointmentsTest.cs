using HospitalLibrary.MedicalRecords.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HospitalIntegrationTests
{
    
    public class ViewAppointmentsTest : IClassFixture<InjectionFixture>
    {
        private readonly InjectionFixture injection;

        public ViewAppointmentsTest(InjectionFixture injection)
        {
            this.injection = injection;
        }

        [Fact]
        public async Task Get_All_Patient_AppointmentsAsync()
        {
            var url = "api/appointment";

            var response = await injection.Client.GetAsync(url);

            response.EnsureSuccessStatusCode();

            var resultString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<Appointment>>(resultString);

            // Assert.Equal(0, result[0].Doctorid);         
            // Assert.Equal(0, result[1].Doctorid);
        }

        [Fact]
        public async Task Get_All_Patient_Completed_AppointmentsAsync()
        {
            var url = "api/appointment/completed";

            var response = await injection.Client.GetAsync(url);

            response.EnsureSuccessStatusCode();

            var resultString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<Appointment>>(resultString);

            // Assert.Equal(0, result[0].Doctorid);         
            // Assert.Equal(0, result[1].Doctorid);
        }
        [Fact]
        public async Task Get_All_Patient_Awaiting_AppointmentsAsync()
        {
            var url = "api/appointment/awaiting";

            var response = await injection.Client.GetAsync(url);

            response.EnsureSuccessStatusCode();

            var resultString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<Appointment>>(resultString);

            // Assert.Equal(0, result[0].Doctorid);         
            // Assert.Equal(0, result[1].Doctorid);
        }
        [Fact]
        public async Task Get_All_Patient_Cancelled_AppointmentsAsync()
        {
            var url = "api/appointment/cancelled";

            var response = await injection.Client.GetAsync(url);

            response.EnsureSuccessStatusCode();

            var resultString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<Appointment>>(resultString);

            // Assert.Equal(0, result[0].Doctorid);         
            // Assert.Equal(0, result[1].Doctorid);
        }
    }
}
