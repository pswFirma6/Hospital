using HospitalAPI.DTO;
using HospitalAPI.DTO.AppointmentDTO;
using HospitalLibrary.GraphicalEditor.Model;
using HospitalLibrary.MedicalRecords.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
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

        [Theory]
        [MemberData(nameof(DataSuccessfully))]
        public async Task Create_New_Appointment_Successfully(NewAppointmentDTO newAppointment,
               DateTime expectedStartTime, int patientId, int doctorId)
        {
            // Arrange //
            var json = JsonConvert.SerializeObject(newAppointment);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var url = "api/appointment";

            // Act //
            var response = await injection.Client.PostAsync(url, data);

            // Assert //
            response.EnsureSuccessStatusCode();

            var resultString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Appointment>(resultString);

            Assert.Equal(result.StartTime, expectedStartTime);
            Assert.Equal(result.PatientId, patientId);
            Assert.Equal(result.DoctorId, doctorId);
        }

        [Theory]
        [MemberData(nameof(DataUnsuccessfully))]
        public async Task Create_New_Appointment_Unsuccessfully(NewAppointmentDTO newAppointment1,
            NewAppointmentDTO newAppointment2)
        {
            // Arrange //
            var json1 = JsonConvert.SerializeObject(newAppointment1);
            var json2 = JsonConvert.SerializeObject(newAppointment2);

            var data1 = new StringContent(json1, Encoding.UTF8, "application/json");
            var data2 = new StringContent(json2, Encoding.UTF8, "application/json");

            var url = "api/appointment";

            // Act //
            var response1 = await injection.Client.PostAsync(url, data1);
            var response2 = await injection.Client.PostAsync(url, data2);


            // Assert //
            Assert.Equal(HttpStatusCode.BadRequest, response1.StatusCode);
            Assert.Equal(HttpStatusCode.BadRequest, response2.StatusCode);


        }

        [Theory]
        [MemberData(nameof(TermSuccessfully))]
        public async Task Return_Free_Appointments_Successfully(TermDTO newTerm, DateTime expectedTermDate, int expectedTermDoctorId)
        {
            // Arrange // 
            var json = JsonConvert.SerializeObject(newTerm);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var url = "api/appointment/doctorAppintments";

            // Act //
            var response = await injection.Client.PostAsync(url, data);

            // Assert //
            response.EnsureSuccessStatusCode();

            var resultString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Appointment>(resultString);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(result.DoctorId, expectedTermDoctorId);
           
        }
       
        public static IEnumerable<object[]> TermSuccessfully()
        {
            var retVal = new List<object[]>();

            var dateString = "1/12/2022 9:00:00 AM";
            DateTime date = DateTime.Parse(dateString,
                                      System.Globalization.CultureInfo.InvariantCulture);

            TermDTO newTerm = new TermDTO( 1,  date);

            var expectedTermDoctorId = 1;
            var expectedTermDate = date;

            retVal.Add(new object[] { newTerm, expectedTermDate, expectedTermDoctorId });

            return retVal;
        }

        public static IEnumerable<object[]> DataSuccessfully()
        {
            var retVal = new List<object[]>();


            Doctor doctor = new Doctor();
            doctor.Id = 1;

            Patient patient = new Patient();
            patient.Id = 2;

            var dateString = "1/12/2022 8:30:00 AM";
            DateTime date = DateTime.Parse(dateString,
                                      System.Globalization.CultureInfo.InvariantCulture);
            NewAppointmentDTO appointmentDTO = new NewAppointmentDTO(date, patient.Id, doctor.Id);

            var expectedStartTime = date;
            var expectedPatientId = 2;
            var expectedDoctorId = 1;

            retVal.Add(new object[] { appointmentDTO, expectedStartTime, expectedPatientId, expectedDoctorId });

            return retVal;
        }

        public static IEnumerable<object[]> DataUnsuccessfully()
        {
            var retVal = new List<object[]>();

            Room room = new Room();
            room.id = 1;

            Doctor doctor = new Doctor();
            doctor.Id = 1;

            Patient patient = new Patient();
            patient.Id = 1;

            var dateString1 = "1/12/2022 8:30:00 AM";
            DateTime date1 = DateTime.Parse(dateString1,
                                      System.Globalization.CultureInfo.InvariantCulture);
            NewAppointmentDTO appointmentDTO1 = new NewAppointmentDTO(date1, -2, patient, doctor.Id, doctor);

            var dateString2 = "1/12/2019 8:30:00 AM";
            DateTime date2 = DateTime.Parse(dateString2,
                                      System.Globalization.CultureInfo.InvariantCulture);
            NewAppointmentDTO appointmentDTO2 = new NewAppointmentDTO(date2, patient.Id, patient, 0, doctor);



            retVal.Add(new object[] { appointmentDTO1, appointmentDTO2 });

            return retVal;
        }

    }
}