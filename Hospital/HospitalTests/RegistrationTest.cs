using HospitalAPI;
using HospitalAPI.ImplService;
using HospitalAPI.Repository;
using HospitalLibrary.MedicalRecords.Model;
using HospitalLibrary.MedicalRecords.Model.Enums;
using HospitalLibrary.Model.Enums;
using MimeKit;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace HospitalTests.UnitTests
{
    public class RegistrationTest
    {
        [Fact]
        public void Check_Create_Email_Message()
        {
            // Arrange //
            List<string> addressesTosend = new List<string>();
            addressesTosend.Add("address1@gmail.com");
            Message message = new Message(addressesTosend, "SubjectTest", "Test");


            EmailSender emailSender = new EmailSender(CreateEmailConfig());

            // Act //
            MimeMessage createdMessage = emailSender.CreateEmailMessage(message);


            // Assert //
            Assert.NotNull(createdMessage.Body);
            Assert.Equal(createdMessage.Subject, message.Subject);
            Assert.Equal(createdMessage.To, message.To);
            Assert.NotNull(createdMessage.From);
        }


        [Fact]
        public void Check_Existing_Patient()
        {
            // Arrange //
            Doctor doctor = new Doctor();
            List<Allergy> allergies = new List<Allergy>();
            Patient newPatient = new Patient("2", "Mira", "Miric", DateTime.Now,
                "0542369712546", "Partizanskih baza 7.", "0666423599", "marko@gmail.com",
                "Mirami", "mira123", Gender.female,
                "Novi Sad", "Serbia", UserType.patient, BloodType.B, RhFactor.positive,
                189, 85, allergies, doctor, false, false);

                   
            PatientService service = new PatientService(CreateStubRepository());

              // Act //
              bool exists = service.CheckExisting(newPatient);

            // Assert //
            Assert.True(exists);
        }

        [Fact]
        public void Check_Not_Existing_Patient()
        {   
            // Arrange //
            Doctor doctor = new Doctor();
            List<Allergy> allergies = new List<Allergy>();
            Patient newPatient = new Patient("2", "Mira", "Miric", DateTime.Now,
            "0542369719085", "Partizanskih baza 7.", "0666423599", "mara@gmail.com",
            "Mirami", "mira123", Gender.female,
            "Novi Sad", "Serbia", UserType.patient, BloodType.B, RhFactor.positive,
            189, 85, allergies, doctor, false, false);

            PatientService service = new PatientService(CreateStubRepository());

            // Act //
            bool exists = service.CheckExisting(newPatient);

            // Assert //
            Assert.False(exists);
        }

        public RepositoryFactory CreateStubRepository()
        {
            var stubRepository = new Mock<RepositoryFactory>();

            Doctor doctor = new Doctor();
            List<Allergy> allergies = new List<Allergy>();
            Patient existingPatient = new Patient("1", "Marko", "Markovic", DateTime.Now,
                "0542369712546", "Maksima Gorkog 7.", "0656423599", "marko@gmail.com",
                "Markoni", "marko123", Gender.male,
                "Novi Sad", "Serbia", UserType.patient, BloodType.A, RhFactor.positive,
                189, 85, allergies, doctor, false, false);
            List<Patient> patients = new List<Patient>();
            patients.Add(existingPatient);

            stubRepository.Setup(m => m.GetPatientRepository().GetAll()).Returns(patients);

            return stubRepository.Object;
        }
        public EmailConfiguration CreateEmailConfig()
        {
            var emailConfig = new Mock<EmailConfiguration>();

            emailConfig.Object.From = "HospitalBeyondCare@gmail.com";
            emailConfig.Object.SmtpServer = "smtp.gmail.com";
            emailConfig.Object.Port = 465;
            emailConfig.Object.UserName = "HospitalBeyondCare@gmail.com";
            emailConfig.Object.Password = "test";

            return emailConfig.Object;
        }
    }
}
