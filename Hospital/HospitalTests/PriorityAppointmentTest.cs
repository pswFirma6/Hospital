using HospitalAPI.DTO.AppointmentDTO;
using HospitalAPI.ImplService;
using HospitalAPI.Repository;
using HospitalLibrary.GraphicalEditor.Model;
using HospitalLibrary.MedicalRecords.Model;
using HospitalLibrary.MedicalRecords.Model.Enums;
using HospitalLibrary.Model.Enums;
using Moq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xunit;

namespace HospitalUnitTests
{
    public class PriorityAppointmentTest
    {
        [Theory]
        [MemberData(nameof(DataGetFreeTerms))]
        public void GetFreeTerms(Doctor doctor, string date, List<string> expectedTerms)
        {
            //  Arrange  //
            AppointmentService service = new AppointmentService(CreateStubRepository());

            //  Act  //
            List<string> TermList = service.GetDoctorsFreeAppointments(doctor.Id, date);


            //  Assert  //

            Assert.Equal(expectedTerms, TermList);
        }


        [Theory]
        [MemberData(nameof(DataNoFreeTerms))]
        public void NoFreeTerms(Doctor doctor, string date, int expectedValue)
        {
            //  Arrange  //
            AppointmentService service = new AppointmentService(CreateNoFreeTermStubRepository());

            //  Act  //
            List<string> TermList = service.GetDoctorsFreeAppointments(doctor.Id, date);


            //  Assert  //
            

            Assert.Equal(TermList.Count, expectedValue);
        }


        [Theory]
        [MemberData(nameof(DataAlternativeDate))]
        public void AlternativeDate(Doctor doctor, string date, List<string> expectedTerms, string expectedDate)
        {
            //  Arragnge  //
            AppointmentService service = new AppointmentService(CreateNoFreeTermStubRepository());
            //  Act  //
            FreeTermsDTO freeTermsDTO = service.GetAlternativeDate(doctor, date);
            //  Assert  //
            
            var freeTermsDTODateString = freeTermsDTO.Date.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
            Assert.Equal(expectedDate, freeTermsDTODateString);
            Assert.Equal(expectedTerms, freeTermsDTO.Terms);

        }

        [Theory]
        [MemberData(nameof(DataAlternativeDoctor))]
        public void AlternativeDoctor(Doctor doctor, string date, List<string> expectedTerms, string expectedDoctorId)
        {
            //  Arragnge  //
            AppointmentService service = new AppointmentService(CreateNoFreeTermStubRepository());
            //  Act  //
            FreeTermsDTO freeTermsDTO = service.GetAlternativeDoctor(doctor, date);
            //  Assert  //

            Assert.Equal(freeTermsDTO.Terms, expectedTerms);
            Assert.Equal(freeTermsDTO.DoctorId, expectedDoctorId);
        }


        public static IEnumerable<object[]> DataGetFreeTerms()
        {
            var retVal = new List<object[]>();
            Doctor doctor = new Doctor();
            doctor.Id = "1";
            string dateString = "12/01/2022";

            List<string> ExpectedTerms = new List<string> {
                "07:00", "07:30",

                "09:00", "09:30",
                "10:00", "10:30",
                "11:00", "11:30",
                "12:00", "12:30",
                "13:00", "13:30",
                "14:00", "14:30",
                "15:00"
            };

            retVal.Add(new object[] { doctor, dateString, ExpectedTerms });
            return retVal;
        }

        public static IEnumerable<object[]> DataNoFreeTerms()
        {
            var retVal = new List<object[]>();
            Doctor doctor = new Doctor();
            doctor.Id = "1";
            string dateString = "12/01/2022";

            int ExpectedValue = 0;

            retVal.Add(new object[] { doctor, dateString, ExpectedValue });
            return retVal;
        }

        public static IEnumerable<object[]> DataAlternativeDate()
        {
            var retVal = new List<object[]>();
            Doctor doctor = new Doctor();
            doctor.Id = "1";
            string dateString = "12/01/2022";

            List<string> ExpectedTerms = new List<string> {
                "07:00", "07:30",
                "08:00", "08:30",
                "09:00", "09:30",
                "10:00", "10:30",
                "11:00", "11:30",
                "12:00", "12:30",
                "13:00", "13:30",
                "14:00", "14:30",
                "15:00"
            };

            var expectedDate = "12/02/2022";

            retVal.Add(new object[] { doctor, dateString, ExpectedTerms, expectedDate });
            return retVal;
        }

        public static IEnumerable<object[]> DataAlternativeDoctor()
        {
            var retVal = new List<object[]>();
            Doctor doctor = new Doctor();
            doctor.Id = "1";
            string dateString = "12/01/2022";

            List<string> ExpectedTerms = new List<string> {
                "07:00", "07:30",
                "08:00", "08:30",
                "09:00", "09:30",
                "10:00", "10:30",
                "11:00", "11:30",
                "12:00", "12:30",
                "13:00", "13:30",
                "14:00", "14:30",
                "15:00"
            };

            string expectedDoctorId = "2";

            retVal.Add(new object[] { doctor, dateString, ExpectedTerms, expectedDoctorId });
            return retVal;
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

            var dateString1 = "12/01/2022 8:00:00 AM";
            DateTime date1 = DateTime.Parse(dateString1,
                                      System.Globalization.CultureInfo.InvariantCulture);
            Appointment appointment1 = new Appointment(date1, room.id, room, patient.Id, patient, "1", doc);
            var dateString2 = "12/01/2022 8:30:00 AM";
            DateTime date2 = DateTime.Parse(dateString2,
                                      System.Globalization.CultureInfo.InvariantCulture);
            Appointment appointment2 = new Appointment(date2, room.id, room, patient.Id, patient, "1", doc);

            appointments.Add(appointment1);
            appointments.Add(appointment2);
            Doctor doctor = new Doctor("1", "Miroslav", "Mikic", DateTime.Now, "2456874215478", "Marka Veselinovica 5."
                    , "0665789461", "milovan@bch.com", "Dr. Miroslav Mikic", "mire123", Gender.male, "Novi Sad"
                    , "Serbia", UserType.doctor, patients, DoctorType.generalPractitioner, appointments);


            stubRepository.Setup(m => m.GetDoctorsRepository().GetOne(doctor.Id)).Returns(doctor);

            return stubRepository.Object;
        }

        public RepositoryFactory CreateNoFreeTermStubRepository()
        {
            var stubRepository = new Mock<RepositoryFactory>();

            Room room = new Room();
            room.id = 1;
            Patient patient = new Patient();
            patient.Id = "1";
            List<Patient> patients = new List<Patient>();
            patients.Add(patient);
            Doctor doc = new Doctor();

            

            var dateString1 = "12/01/2022 7:00:00 AM";
            DateTime date1 = DateTime.Parse(dateString1,
                                      System.Globalization.CultureInfo.InvariantCulture);
            Appointment appointment1 = new Appointment(date1, room.id, room, patient.Id, patient, "1", doc);

            var dateString2 = "12/01/2022 7:30:00 AM";
            DateTime date2 = DateTime.Parse(dateString2,
                                      System.Globalization.CultureInfo.InvariantCulture);
            Appointment appointment2 = new Appointment(date2, room.id, room, patient.Id, patient, "1", doc);

            var dateString3 = "12/01/2022 8:00:00 AM";
            DateTime date3 = DateTime.Parse(dateString3,
                                      System.Globalization.CultureInfo.InvariantCulture);
            Appointment appointment3 = new Appointment(date3, room.id, room, patient.Id, patient, "1", doc);

            var dateString4 = "12/01/2022 8:30:00 AM";
            DateTime date4 = DateTime.Parse(dateString4,
                                      System.Globalization.CultureInfo.InvariantCulture);
            Appointment appointment4 = new Appointment(date4, room.id, room, patient.Id, patient, "1", doc);

            var dateString5 = "12/01/2022 9:00:00 AM";
            DateTime date5 = DateTime.Parse(dateString5,
                                      System.Globalization.CultureInfo.InvariantCulture);
            Appointment appointment5 = new Appointment(date5, room.id, room, patient.Id, patient, "1", doc);

            var dateString6 = "12/01/2022 9:30:00 AM";
            DateTime date6 = DateTime.Parse(dateString6,
                                      System.Globalization.CultureInfo.InvariantCulture);
            Appointment appointment6 = new Appointment(date6, room.id, room, patient.Id, patient, "1", doc);

            var dateString7 = "12/01/2022 10:00:00 AM";
            DateTime date7 = DateTime.Parse(dateString7,
                                      System.Globalization.CultureInfo.InvariantCulture);
            Appointment appointment7 = new Appointment(date7, room.id, room, patient.Id, patient, "1", doc);

            var dateString8 = "12/01/2022 10:30:00 AM";
            DateTime date8 = DateTime.Parse(dateString8,
                                      System.Globalization.CultureInfo.InvariantCulture);
            Appointment appointment8 = new Appointment(date8, room.id, room, patient.Id, patient, "1", doc);

            var dateString9 = "12/01/2022 11:00:00 AM";
            DateTime date9 = DateTime.Parse(dateString9,
                                      System.Globalization.CultureInfo.InvariantCulture);
            Appointment appointment9 = new Appointment(date9, room.id, room, patient.Id, patient, "1", doc);

            var dateString10 = "12/01/2022 11:30:00 AM";
            DateTime date10 = DateTime.Parse(dateString10,
                                      System.Globalization.CultureInfo.InvariantCulture);
            Appointment appointment10 = new Appointment(date10, room.id, room, patient.Id, patient, "1", doc);

            var dateString11 = "12/01/2022 12:00:00 PM";
            DateTime date11 = DateTime.Parse(dateString11,
                                      System.Globalization.CultureInfo.InvariantCulture);
            Appointment appointment11 = new Appointment(date11, room.id, room, patient.Id, patient, "1", doc);

            var dateString12 = "12/01/2022 12:30:00 PM";
            DateTime date12 = DateTime.Parse(dateString12,
                                      System.Globalization.CultureInfo.InvariantCulture);
            Appointment appointment12 = new Appointment(date12, room.id, room, patient.Id, patient, "1", doc);

            var dateString13 = "12/01/2022 01:00:00 PM";
            DateTime date13 = DateTime.Parse(dateString13,
                                      System.Globalization.CultureInfo.InvariantCulture);
            Appointment appointment13 = new Appointment(date13, room.id, room, patient.Id, patient, "1", doc);

            var dateString14 = "12/01/2022 01:30:00 PM";
            DateTime date14 = DateTime.Parse(dateString14,
                                      System.Globalization.CultureInfo.InvariantCulture);
            Appointment appointment14 = new Appointment(date14, room.id, room, patient.Id, patient, "1", doc);

            var dateString15 = "12/01/2022 02:00:00 PM";
            DateTime date15 = DateTime.Parse(dateString15,
                                      System.Globalization.CultureInfo.InvariantCulture);
            Appointment appointment15 = new Appointment(date15, room.id, room, patient.Id, patient, "1", doc);

            var dateString16 = "12/01/2022 02:30:00 PM";
            DateTime date16 = DateTime.Parse(dateString16,
                                      System.Globalization.CultureInfo.InvariantCulture);
            Appointment appointment16 = new Appointment(date16, room.id, room, patient.Id, patient, "1", doc);

            var dateString17 = "12/01/2022 03:00:00 PM";
            DateTime date17 = DateTime.Parse(dateString17,
                                      System.Globalization.CultureInfo.InvariantCulture);
            Appointment appointment17 = new Appointment(date17, room.id, room, patient.Id, patient, "1", doc);

            List<Appointment> appointments = new List<Appointment>() { 
                appointment1, appointment2,
                appointment3, appointment4,
                appointment5, appointment6,
                appointment7, appointment8,
                appointment9, appointment10,
                appointment11, appointment12,
                appointment13, appointment14,
                appointment15, appointment16,
                appointment17, 
            };

            Doctor doctor = new Doctor("1", "Miroslav", "Mikic", DateTime.Now, "2456874215478", "Marka Veselinovica 5."
                    , "0665789461", "milovan@bch.com", "Dr. Miroslav Mikic", "mire123", Gender.male, "Novi Sad"
                    , "Serbia", UserType.doctor, patients, DoctorType.generalPractitioner, appointments);

            List<Appointment> appointments2 = new List<Appointment>();
            Doctor doctor2 = new Doctor("2", "Miroslav", "Mikic", DateTime.Now, "2456874215478", "Marka Veselinovica 5."
                    , "0665789461", "milovan@bch.com", "Dr. Miroslav Mikic", "mire123", Gender.male, "Novi Sad"
                    , "Serbia", UserType.doctor, patients, DoctorType.generalPractitioner, appointments2);

            List<Doctor> doctors = new List<Doctor>() { doctor, doctor2 };

            stubRepository.Setup(m => m.GetDoctorsRepository().GetOne(doctor.Id)).Returns(doctor);
            stubRepository.Setup(m => m.GetDoctorsRepository().GetOne(doctor2.Id)).Returns(doctor2);
            stubRepository.Setup(m => m.GetDoctorsRepository().GetAll()).Returns(doctors);

            return stubRepository.Object;
        }
    }
}
