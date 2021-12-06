using HospitalLibrary.MedicalRecords.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital_library.MedicalRecords.Model
{
    public class Prescription : Entity
    {
        public string MedicineName { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public string RecommendedDose { get; set; }
        public string PrescriptionDate { get; set; }
        public string DoctorName { get; set; }
        public string PatientName { get; set; }
        public string PatientId { get; set; }
        public string TherapyStart { get; set; }
        public string TherapyEnd { get; set; }
        public string Diagnosis { get; set; }
        public string PharmacyName { get; set; }

        public Prescription() { }

        public Prescription(string medicineName, int quantity, string description, string recommendedDose, string prescriptionDate, string doctorName, string patientName, string patientId, string therapyStart, string therapyEnd, string diagnosis, string pharmacyName)
        {
            MedicineName = medicineName;
            Quantity = quantity;
            Description = description;
            RecommendedDose = recommendedDose;
            PrescriptionDate = prescriptionDate;
            DoctorName = doctorName;
            PatientName = patientName;
            PatientId = patientId;
            TherapyStart = therapyStart;
            TherapyEnd = therapyEnd;
            Diagnosis = diagnosis;
            PharmacyName = pharmacyName;
        }
    }
}
