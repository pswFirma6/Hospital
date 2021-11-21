using Hospital_API.ImplService;
using Hospital_API.Repository;
using Hospital_library.MedicalRecords.Model;
using Hospital_library.MedicalRecords.Model.Enums;
using Hospital_library.MedicalRecords.Repository.Interface;
using Hospital_library.MedicalRecords.Repository.Repository.Interface;
using Moq;
using Shouldly;
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
            // Arange //
            Doctor doctor = new Doctor();
            List<Allergy> allergies = new List<Allergy>();
            Patient newPatient = new Patient("2", "Mira", "Miric", DateTime.Now,
                "0542369712546", "Partizanskih baza 7.", "0666423599", "marko@gmail.com",
                "Mirami", "mira123", Hospital_library.Model.Enumeration.Gender.female,
                "Novi Sad", "Serbia", UserType.patient, BloodType.B, RhFactor.positive,
                189, 85, doctor, allergies);

            PatientService service = new PatientService(CreateStubRepository(newPatient));
            
            // Act //
            Patient p = service.Register(newPatient);
            
            // Assert //
            p.ShouldBeNull();
        }

        [Fact]
        public void Check_Not_Existing_Patient()
        {   
            // Arange //
            Doctor doctor = new Doctor();
            List<Allergy> allergies = new List<Allergy>();
            Patient newPatient = new Patient("2", "Mira", "Miric", DateTime.Now,
            "0542369719085", "Partizanskih baza 7.", "0666423599", "mara@gmail.com",
            "Mirami", "mira123", Hospital_library.Model.Enumeration.Gender.female,
            "Novi Sad", "Serbia", UserType.patient, BloodType.B, RhFactor.positive,
            189, 85, doctor, allergies);

            PatientService service = new PatientService(CreateStubRepository(newPatient));

            // Act //
            Patient p = service.Register(newPatient);

            // Assert //
            p.ShouldNotBeNull();
        }

        public IPatientRepository  CreateStubRepository(Patient newPatient)
        {
            var stubRepository = new Mock<IPatientRepository>();
            Doctor doctor = new Doctor();
            List<Allergy> allergies = new List<Allergy>();
            Patient existingPatient = new Patient("1", "Marko", "Markovic", DateTime.Now,
                "0542369712546", "Maksima Gorkog 7.", "0656423599", "marko@gmail.com",
                "Markoni", "marko123", Hospital_library.Model.Enumeration.Gender.male,
                "Novi Sad", "Serbia", UserType.patient, BloodType.A, RhFactor.positive,
                189, 85, doctor, allergies);
            List<Patient> patients = new List<Patient>();
            patients.Add(existingPatient);

            stubRepository.Setup(m => m.GetAll()).Returns(patients);
            stubRepository.Setup(m => m.Add(newPatient)).Returns(newPatient);

            return stubRepository.Object;
        }
    }
}
