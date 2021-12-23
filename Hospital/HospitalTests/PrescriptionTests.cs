using Hospital_library.MedicalRecords.Model;
using HospitalAPI.ImplService;
using HospitalAPI.Validation;
using HospitalLibraryHospital_library.MedicalRecords.Repository;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace HospitalUnitTests
{
    public class PrescriptionTests
    {
        private PrescriptionValidation prescriptionValidation = new PrescriptionValidation();

        [Fact]
        public void Add_Prescription()
        {   
            // Arrange //
            var stubRepository = new Mock<RepositoryFactory>();
            PrescriptionService service = new PrescriptionService(stubRepository.Object);
            List<Prescription> prescriptions = new List<Prescription>();
            Prescription prescription = new Prescription
            {
                Id = 2,
                MedicineName = "Brufen",
                Quantity = 2,
                RecommendedDose = "2 times a day",
                PrescriptionDate = "22.11.2021.",
                DoctorName = "Branimir Nestorovic",
                PatientName = "Ognjen Bogdanovic",
                TherapyStart = "Dec 1, 2021",
                TherapyEnd = "Dec 31, 2021",
                Diagnosis = "Headache",
                PharmacyName = "Benu"
            };

            stubRepository.Setup(m => m.GetPrescriptionRepository().Add(prescription)).Callback((Prescription p) => prescriptions.Add(p));

            // Act //
            prescriptionValidation.AreDatesValid(prescription.TherapyStart, prescription.TherapyEnd);
            service.AddPrescription(prescription);

            // Assert //
            prescriptions.ShouldNotBeEmpty();
        }

        [Fact]
        public void Check_Valid_Prescription_Dates()
        {
            // Arrange //
            bool areDatesValid;
            string start = "Dec 1, 2021";
            string end = "Dec 31, 2021";

            // Act //
            areDatesValid = prescriptionValidation.AreDatesValid(start, end);

            // Assert //
            areDatesValid.ShouldBeTrue();
        }

        [Fact]
        public void Check_Invalid_Prescription_Dates()
        {
            // Arrange //
            PrescriptionValidation prescriptionValidation = new PrescriptionValidation();
            bool areDatesValid;
            string start = "Dec 31, 2021";
            string end = "Dec 1, 2021";


            // Act //
            areDatesValid = prescriptionValidation.AreDatesValid(start, end);

            // Assert //
            areDatesValid.ShouldBeFalse();
        }

    }
}
