using Hospital_library.MedicalRecords.Model.Events;
using HospitalAPI.DTO.EventDTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HospitalIntegrationTests
{
    public class EventSourcingTest : IClassFixture<InjectionFixture>
    {
        private readonly InjectionFixture injection;
        public EventSourcingTest(InjectionFixture injection)
        {
            this.injection = injection;
        }

        [Theory]
        [MemberData(nameof(DataSuccessfully))]
        public async Task Create_New_Event_Successfully(EventAppointmentDTO newEvent,
             DateTime expectedClickTime, int appointmentId)
        {
            // Arrange //
            var json = JsonConvert.SerializeObject(newEvent);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var url = "api/event/addEvent";

            // Act //
            var response = await injection.Client.PostAsync(url, data);

            // Assert //
            response.EnsureSuccessStatusCode();

            var resultString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<AppointmentEvent>(resultString);

            Assert.Equal(result.ClickTime, expectedClickTime);
            Assert.Equal(result.DoctorId, appointmentId);
            Assert.Equal("AppForPatient", result.ApplicationName);
        }

        [Theory]
        [MemberData(nameof(DataEventStepSuccessfully))]
        public async Task Create_New_StepEvent_Successfully(EventStepDTO newEvent,
                 DateTime expectedClickTime, int appointmentId)
        {
            // Arrange //
            var json = JsonConvert.SerializeObject(newEvent);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var url = "api/event/addEventStep";

            // Act //
            var response = await injection.Client.PostAsync(url, data);

            // Assert //
            response.EnsureSuccessStatusCode();

            var resultString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<EventStep>(resultString);

            Assert.Equal(result.ClickTime, expectedClickTime);
            Assert.Equal(result.AppointmentEventId, appointmentId);
        }

        public static IEnumerable<object[]> DataSuccessfully()
        {
            var retVal = new List<object[]>();

            var dateString = DateTime.Now.ToString();
            DateTime date = DateTime.Parse(dateString,
                                      System.Globalization.CultureInfo.InvariantCulture);
            EventAppointmentDTO eventDTO = new EventAppointmentDTO("addFeedback", date, 
                "AppForPatient", 100, 1, new List<EventStepDTO>(), true);
            
            var expectedClickTime = date;
            var expectedAppointmentId = 1;

            retVal.Add(new object[] { eventDTO, expectedClickTime, expectedAppointmentId });

            return retVal;
        }

        public static IEnumerable<object[]> DataEventStepSuccessfully()
        {
            var retVal = new List<object[]>();

            var dateString = DateTime.Now.ToString();
            DateTime date = DateTime.Parse(dateString,
                                      System.Globalization.CultureInfo.InvariantCulture);
            EventStepDTO eventDTO = new EventStepDTO("addFeedback", 100, date, 1);

            var expectedClickTime = date;
            var expectedAppEventId = 1;

            retVal.Add(new object[] { eventDTO, expectedClickTime, expectedAppEventId });

            return retVal;
        }
        
    }
}
