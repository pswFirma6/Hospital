using HospitalAPI.DTO;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Xunit;

namespace HospitalIntegrationTests
{
    public class CreateNewAppointmentTest : IClassFixture<InjectionFixture>
    {
        private readonly InjectionFixture injection;
        public CreateNewAppointmentTest(InjectionFixture injection)
        {
            this.injection = injection;
        }

        /*
        [Theory]
        [MemberData(nameof(Data))]
        public Create_New_Appointment_Successfully(NewAppointmentDTO newAppointmentDTO)
        {
            // Arrange //
            var json = JsonConvert.SerializeObject(newAppointmentDTO);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var url = "api/appoitment";


            Assert.NotNull();
        }
        */
        public static IEnumerable<object[]> Data()
        {
            var retVal = new List<object[]>();

            return retVal;
        }

    }
}