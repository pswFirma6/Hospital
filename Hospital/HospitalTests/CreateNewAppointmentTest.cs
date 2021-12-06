using HospitalAPI.ImplService;
using HospitalAPI.Repository;
using HospitalLibrary.GraphicalEditor.Model;
using HospitalLibrary.MedicalRecords.Model;
using HospitalLibrary.MedicalRecords.Model.Enums;
using HospitalLibrary.Model.Enums;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace HospitalUnitTests
{
    public class CreateNewAppointmentTest
    {
        [Theory]
        [MemberData(nameof(ExistingData))]
        public void Check_Existing_Doctor_Appointment(Appointment newAppointment1, Appointment newAppointment2)
        {   
            //  Arrange  //
            AppointmentService service =  new AppointmentService(CreateStubRepository());

            //  Act  //
            bool exists1 = service.CheckDoctorAppointments(newAppointment1);
            bool exists2 = service.CheckDoctorAppointments(newAppointment2);

            //  Assert  //
            Assert.True(exists1);
            Assert.True(exists2);
        }

        [Theory]
        [MemberData(nameof(NotExistingData))]
        public void Check_Not_Existing_Doctor_Appointment(Appointment newAppointment1, Appointment newAppointment2)
        {
            //  Arrange  //
            AppointmentService service = new AppointmentService(CreateStubRepository());

            //  Act  //
            bool exists1 = service.CheckDoctorAppointments(newAppointment1);
            bool exists2 = service.CheckDoctorAppointments(newAppointment2);

            //  Assert  //
            Assert.False(exists1);
            Assert.False(exists2);

        }

        public RepositoryFactory CreateStubRepository()
        {
            var stubRepository = new Mock<RepositoryFactory>();

            Room room = new Room();
            room.id = 1;
            Patient patient = new Patient();
            patient.Id = "1";
            List<Patient> patients = new List<Patient>();
            patients.Add(patient);
            Doctor doc = new Doctor();
            
            List<Appointment> appointments = new List<Appointment>();
            
            var dateString1 = "1/12/2022 8:30:00 AM";
            DateTime date1 = DateTime.Parse(dateString1,
                                      System.Globalization.CultureInfo.InvariantCulture);
            Appointment appointment1 = new Appointment(date1, 30.00,
                date1, room.id, room, patient.Id, patient, "1", doc);
            var dateString2 = "1/14/2022 8:30:00 AM";
            DateTime date2 = DateTime.Parse(dateString2,
                                      System.Globalization.CultureInfo.InvariantCulture);
            Appointment appointment2 = new Appointment(date2, 30.00,
                date2, room.id, room, patient.Id, patient, "1", doc);

            appointments.Add(appointment1);
            appointments.Add(appointment2);
            Doctor doctor = new Doctor("1", "Miroslav", "Mikic", DateTime.Now, "2456874215478", "Marka Veselinovica 5."
                    , "0665789461", "milovan@bch.com", "Dr. Miroslav Mikic", "mire123", Gender.male, "Novi Sad"
                    , "Serbia", UserType.doctor, patients, DoctorType.generalPractitioner, appointments);

            
            stubRepository.Setup(m => m.GetDoctorsRepository().GetOne(doctor.Id)).Returns(doctor);

            return stubRepository.Object;
        }

        public static IEnumerable<object[]> ExistingData()
        {
            var retVal = new List<object[]>();

            Room room = new Room();
            room.id = 1;
            Patient patient = new Patient();
            patient.Id = "1";
            List<Patient> patients = new List<Patient>();
            patients.Add(patient);
            Doctor doc = new Doctor();

            var dateString1 = "1/12/2022 8:30:00 AM";
            DateTime date1 = DateTime.Parse(dateString1,
                                      System.Globalization.CultureInfo.InvariantCulture);
            Appointment appointment1 = new Appointment(date1, 30.00,
                date1, room.id, room, patient.Id, patient, "1", doc);
            var dateString2 = "1/14/2022 8:37:00 AM";
            DateTime date2 = DateTime.Parse(dateString2,
                                      System.Globalization.CultureInfo.InvariantCulture);
            Appointment appointment2 = new Appointment(date2, 30.00,
                date2, room.id, room, patient.Id, patient, "1", doc);

            retVal.Add(new object[] { appointment1, appointment2 });

            return retVal;
        }

        public static IEnumerable<object[]> NotExistingData()
        {
            var retVal = new List<object[]>();

            Room room = new Room();
            room.id = 1;
            Patient patient = new Patient();
            patient.Id = "1";
            List<Patient> patients = new List<Patient>();
            patients.Add(patient);
            Doctor doc = new Doctor();

            var dateString1 = "2/12/2022 8:30:00 AM";
            DateTime date1 = DateTime.Parse(dateString1,
                                      System.Globalization.CultureInfo.InvariantCulture);
            Appointment appointment1 = new Appointment(date1, 30.00,
                date1, room.id, room, patient.Id, patient, "1", doc);
            var dateString2 = "1/12/2022 9:10:00 AM";
            DateTime date2 = DateTime.Parse(dateString2,
                                      System.Globalization.CultureInfo.InvariantCulture);
            Appointment appointment2 = new Appointment(date2, 30.00,
                date2, room.id, room, patient.Id, patient, "1", doc);

            retVal.Add(new object[] { appointment1, appointment2 });

            return retVal;
        }

    }
}
