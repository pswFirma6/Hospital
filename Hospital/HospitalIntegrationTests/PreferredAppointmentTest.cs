using HospitalAPI.DTO;
using HospitalAPI.ImplService;
using HospitalLibrary.GraphicalEditor.Model;
using HospitalLibrary.MedicalRecords.Model;
using HospitalLibrary.MedicalRecords.Model.Enums;
using HospitalLibraryHospital_library.MedicalRecords.Repository;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Xunit;

namespace HospitalIntegrationTests
{
    public class PreferredAppointmentTest : IClassFixture<InjectionFixture>
    {
        private readonly InjectionFixture injection;
        public PreferredAppointmentTest(InjectionFixture injection)
        {
            this.injection = injection;
        }

        [Theory]
        [MemberData(nameof(DataSuccessfully))]
        public async System.Threading.Tasks.Task Get_Doctors_Appointments(PreferredAppointmentRequestDTO appointmentRequestDTO)
        {
            AppointmentService appointmentService = new AppointmentService(CreateStubRepository());
            var json = JsonConvert.SerializeObject(appointmentRequestDTO);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var url = "api/appointment/priority";

            var response = await injection.Client.PostAsync(url, data);

            response.EnsureSuccessStatusCode();

            Assert.NotNull(response);
        }


        public static IEnumerable<object[]> DataSuccessfully()
        {
            var retVal = new List<object[]>();

            Doctor doctor = new Doctor();
            doctor.Id = 1;
            PreferredAppointmentRequestDTO appointmentRequestDTO = new PreferredAppointmentRequestDTO(
                    "01/12/2021", doctor.Id, DoctorType.surgery, "doctor"
                );

            retVal.Add(new object[] { appointmentRequestDTO });

            return retVal;
        }

        public RepositoryFactory CreateStubRepository()
        {
            var stubRepository = new Mock<RepositoryFactory>();

            Room room = new Room();
            room.id = 1;
            Doctor doctor = new Doctor();
            doctor.Id = 1;
            Patient patient = new Patient();
            patient.Id = 1;
            var dateString1 = "01/12/2021 8:30:00 AM";
            DateTime date1 = DateTime.Parse(dateString1,
                                      System.Globalization.CultureInfo.InvariantCulture);
            Appointment appointment1 = new Appointment(date1, patient.Id, patient, doctor.Id, doctor);
            var dateString2 = "01/12/2021 9:00:00 AM";
            DateTime date2 = DateTime.Parse(dateString2,
                                      System.Globalization.CultureInfo.InvariantCulture);
            Appointment appointment2 = new Appointment(date2, patient.Id, patient, doctor.Id, doctor);
            var dateString3 = "01/12/2021 9:30:00 AM";
            DateTime date3 = DateTime.Parse(dateString3,
                                      System.Globalization.CultureInfo.InvariantCulture);
            Appointment appointment3 = new Appointment(date3, patient.Id, patient, doctor.Id, doctor);

            
            List<Appointment> doctorsAppointments = new List<Appointment>();
            doctorsAppointments.Add(appointment1);
            doctorsAppointments.Add(appointment2);
            doctorsAppointments.Add(appointment3);

            doctor.Appointments = doctorsAppointments;

            stubRepository.Setup(m => m.GetAppointmentsRepository().GetAll()).Returns(doctorsAppointments);

            List<Doctor> doctors = new List<Doctor>();
            doctors.Add(doctor);
            //stubRepository.Setup(m => m.GetDoctorsRepository().GetAll()).Returns(doctors);
            return stubRepository.Object;
        }
    }
}
