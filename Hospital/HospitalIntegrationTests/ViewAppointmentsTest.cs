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
            var url = "api/appointment/5";

            var response = await injection.Client.GetAsync(url);

            response.EnsureSuccessStatusCode();

            var resultString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<Appointment>>(resultString);

            Assert.Equal(0, result[0].DoctorId);
            Assert.Equal(0, result[1].DoctorId);
        }

        [Fact]
        public async Task Get_All_Patient_Completed_AppointmentsAsync()
        {
            var url = "api/appointment/completed/5";

            var response = await injection.Client.GetAsync(url);

            response.EnsureSuccessStatusCode();

            var resultString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<Appointment>>(resultString);

            Assert.Equal(0, result[0].DoctorId);
            Assert.Equal(0, result[1].DoctorId);
        }
        [Fact]
        public async Task Get_All_Patient_Awaiting_AppointmentsAsync()
        {
            var url = "api/appointment/awaiting/5";

            var response = await injection.Client.GetAsync(url);

            response.EnsureSuccessStatusCode();

            var resultString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<Appointment>>(resultString);

             Assert.Equal(0, result[0].DoctorId);         
             Assert.Equal(0, result[1].DoctorId);
        }
        [Fact]
        public async Task Get_All_Patient_Cancelled_AppointmentsAsync()
        {
            var url = "api/appointment/cancelled/5";

            var response = await injection.Client.GetAsync(url);

            response.EnsureSuccessStatusCode();

            var resultString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<Appointment>>(resultString);

            Assert.Equal(0, result[0].DoctorId);
            Assert.Equal(0, result[1].DoctorId);
        }
    }
}
