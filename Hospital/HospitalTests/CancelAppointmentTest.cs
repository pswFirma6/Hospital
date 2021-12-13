using Hospital_library.MedicalRecords.Model.Enums;
using HospitalAPI.ImplService;
using HospitalAPI.Repository;
using HospitalLibrary.GraphicalEditor.Model;
using HospitalLibrary.MedicalRecords.Model;
using HospitalLibrary.MedicalRecords.Model.Enums;
using HospitalLibrary.Model.Enums;
using HospitalLibraryHospital_library.MedicalRecords.Repository;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace HospitalUnitTests
{
    public class CancelAppointmentTest
    {
        [Theory]
        [MemberData(nameof(ExistingData))]
        public void Check_Existing_Appointment(Appointment newAppointment)
        {
            //  Arrange  //
            AppointmentService service = new AppointmentService(CreateStubRepository());

            //  Act  //
            bool exists1 = service.CheckExistingAppointment(newAppointment);

            //  Assert  //
            Assert.True(exists1);

        }

        [Theory]
        [MemberData(nameof(NotExistingData))]
        public void Check_Not_Existing_Appointment(Appointment newAppointment)
        {
            //  Arrange  //
            AppointmentService service = new AppointmentService(CreateStubRepository());

            //  Act  //
            bool exists1 = service.CheckExistingAppointment(newAppointment);

            //  Assert  //
            Assert.False(exists1);

        }
        [Theory]
        [MemberData(nameof(ExistingData))]
        public void Check_cancel_Appointment(Appointment newAppointment)
        {
            //  Arrange  //
            AppointmentService service = new AppointmentService(CreateStubRepository());

            //  Act  //
            service.CancelAppointment(newAppointment);

            //  Assert  //
            Assert.Equal(AppointmentType.Cancelled, newAppointment.Type);

        }
        [Theory]
        [MemberData(nameof(CancelledData))]
        public void Check_failed_cancel_Appointment(Appointment newAppointment)
        {
            //  Arrange  //
            AppointmentService service = new AppointmentService(CreateStubRepository());

            //  Act  //
            service.CancelAppointment(newAppointment);

            //  Assert  //
            Assert.Equal(AppointmentType.Cancelled, newAppointment.Type);

        }

        public static IEnumerable<object[]> ExistingData()
        {
            var retVal = new List<object[]>();

            Room room = new Room();
            room.id = 1;
            Patient patient = new Patient();
            patient.Id = 1;
            List<Patient> patients = new List<Patient>();
            patients.Add(patient);
            Doctor doc = new Doctor();


            var dateString = "1/12/2022 8:30:00 AM";
            DateTime date = DateTime.Parse(dateString,
                                      System.Globalization.CultureInfo.InvariantCulture);

            Appointment appointment = new Appointment(date, patient.Id, patient, 1, doc, AppointmentType.Awaiting);


            retVal.Add(new object[] { appointment });

            return retVal;
        }
        public static IEnumerable<object[]> CancelledData()
        {
            var retVal = new List<object[]>();

            Room room = new Room();
            room.id = 1;
            Patient patient = new Patient();
            patient.Id = 1;
            List<Patient> patients = new List<Patient>();
            patients.Add(patient);
            Doctor doc = new Doctor();


            var dateString = "1/12/2022 8:30:00 AM";
            DateTime date = DateTime.Parse(dateString,
                                      System.Globalization.CultureInfo.InvariantCulture);

            Appointment appointment = new Appointment(date, patient.Id, patient, 1, doc, AppointmentType.Cancelled);


            retVal.Add(new object[] { appointment });

            return retVal;
        }
        public static IEnumerable<object[]> NotExistingData()
        {
            var retVal = new List<object[]>();

            Room room = new Room();
            room.id = 1;
            Patient patient = new Patient();
            patient.Id = 1;
            List<Patient> patients = new List<Patient>();
            patients.Add(patient);
            Doctor doc = new Doctor();


            var dateString = "1/14/2022 8:30:00 AM";
            DateTime date = DateTime.Parse(dateString,
                                      System.Globalization.CultureInfo.InvariantCulture);

            Appointment appointment = new Appointment(date,  patient.Id, patient, 1, doc, AppointmentType.Cancelled);

            retVal.Add(new object[] { appointment });

            return retVal;
        }

        public RepositoryFactory CreateStubRepository()
        {
            var stubRepository = new Mock<RepositoryFactory>();

            Room room = new Room();
            room.id = 1;
            Patient patient = new Patient();
            patient.Id = 1;
            List<Patient> patients = new List<Patient>();
            patients.Add(patient);
            Doctor doc = new Doctor();


            var dateString = "1/12/2022 8:30:00 AM";
            DateTime date = DateTime.Parse(dateString,
                                      System.Globalization.CultureInfo.InvariantCulture);

            Appointment appointment = new Appointment(date,
                 patient.Id, patient, 1, doc, AppointmentType.Awaiting);



            stubRepository.Setup(m => m.GetAppointmentsRepository().GetOne(appointment.Id)).Returns(appointment);

            return stubRepository.Object;
        }
    }
}