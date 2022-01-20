using HospitalLibrary.MedicalRecords.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital_library.MedicalRecords.Model
{
    public class Prescription : Entity
    {
        public string MedicineName { get; set; }
        public  Dosage Dosage { get; set; }
        public string DoctorName { get; set; }
        public string PatientName { get; set; }
        public Therapy Therapy { get; set; }
        public string PharmacyName { get; set; }

        public virtual Appointment Appointment { get; set; }


        public Prescription() { }

        public Prescription(string medicineName, int quantity, string recommendedDose, string prescriptionDate, string doctorName, string patientName, string therapyStart, string therapyEnd, string diagnosis, string pharmacyName)
        {
            MedicineName = medicineName;
            Dosage = new Dosage(quantity, recommendedDose, prescriptionDate);
            DoctorName = doctorName;
            PatientName = patientName;
            Therapy = new Therapy(therapyStart, therapyEnd, diagnosis);
            PharmacyName = pharmacyName;
        }

        

    }
}
