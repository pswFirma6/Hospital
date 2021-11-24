using AutoMapper;
using Hospital_API.ImplService;
using Hospital_library.MedicalRecords.Model;
using Hospital_library.MedicalRecords.Model.Enums;
using Hospital_library.MedicalRecords.Repository.Repository.Interface;
using Hospital_library.MedicalRecords.Service;
using Microsoft.AspNetCore.Identity;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace HospitalTests.UnitTests
{
    public class RegistrationTest
    {

        [Fact]
        public void Check_Existing_Patient()
        {
            // Arrange //
            Doctor doctor = new Doctor();
            List<Allergy> allergies = new List<Allergy>();
            Patient newPatient = new Patient("2", "Mira", "Miric", DateTime.Now,
                "0542369712546", "Partizanskih baza 7.", "0666423599", "marko@gmail.com",
                "Mirami", "mira123", HospitalLibrary.Model.Enumeration.Gender.female,
                "Novi Sad", "Serbia", UserType.patient, BloodType.B, RhFactor.positive,
                189, 85, allergies, doctor);

         
            var mapperMock = new Mock<IMapper>();
            PatientService service = new PatientService(CreateStubRepository(), mapperMock.Object);

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
            "Mirami", "mira123", HospitalLibrary.Model.Enumeration.Gender.female,
            "Novi Sad", "Serbia", UserType.patient, BloodType.B, RhFactor.positive,
            189, 85, allergies, doctor);


            var mapperMock = new Mock<IMapper>();
            PatientService service = new PatientService(CreateStubRepository(), mapperMock.Object);

            // Act //
            bool exists = service.CheckExisting(newPatient);

            // Assert //
            Assert.False(exists);
        }

        public IPatientRepository CreateStubRepository()
        {
            var stubRepository = new Mock<IPatientRepository>();
            Doctor doctor = new Doctor();
            List<Allergy> allergies = new List<Allergy>();
            Patient existingPatient = new Patient("1", "Marko", "Markovic", DateTime.Now,
                "0542369712546", "Maksima Gorkog 7.", "0656423599", "marko@gmail.com",
                "Markoni", "marko123", HospitalLibrary.Model.Enumeration.Gender.male,
                "Novi Sad", "Serbia", UserType.patient, BloodType.A, RhFactor.positive,
                189, 85, allergies, doctor);
            List<Patient> patients = new List<Patient>();
            patients.Add(existingPatient);

            stubRepository.Setup(m => m.GetAll()).Returns(patients);

            return stubRepository.Object;
        }
    }
}
