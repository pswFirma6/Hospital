using Hospital_library.MedicalRecords.Model;
using HospitalAPI.ImplService;
using HospitalAPI.Repository;
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
                Description = "",
                RecommendedDose = "2 times a day",
                PrescriptionDate = "22.11.2021.",
                DoctorName = "Branimir Nestorovic",
                PatientName = "Ognjen Bogdanovic",
                PatientId = "123456",
                TherapyStart = "22.11.2021.",
                TherapyEnd = "01.01.2022.",
                Diagnosis = "Headache",
                PharmacyName = "Benu"
            };

            stubRepository.Setup(m => m.GetPrescriptionRepository().Add(prescription)).Callback((Prescription p) => prescriptions.Add(p));

            // Act //
            service.AddPrescription(prescription);

            // Assert //
            prescriptions.ShouldNotBeEmpty();
        }

    }
}
