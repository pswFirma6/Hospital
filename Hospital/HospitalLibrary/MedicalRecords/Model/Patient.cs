using HospitalLibrary.MedicalRecords.Model.Enums;
using HospitalLibrary.Model.Enums;
using System;
using System.Collections.Generic;

namespace HospitalLibrary.MedicalRecords.Model
{
    public class Patient : User
    {
        public BloodType BloodType { get; set; }
        public RhFactor RhFactor { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public virtual ICollection<Allergy> Allergies { get; set; }
        public int DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }
        public bool Blocked { get; set; }
        public bool Malicious { get; set; }
        public List<DateTime> CanceledAppointments { get; set; }

        public Patient()
        {
        }
        public Patient(int id, string name, string surname, DateTime birthDate,
            string jmbg, string address, string phone, string email, string username,
            string password, Gender gender, string city, string country, UserType userType,
            BloodType bloodType, RhFactor rhfactor, int height, int weight, List<Allergy> allergies,
            Doctor doctor, bool blocked, bool malicious, List<DateTime> canceledAppointments)
            : base(id, name, surname, birthDate, jmbg, address, phone, email, username,
                  password, gender, city, country, userType)
        {
            BloodType = bloodType;
            RhFactor = rhfactor;
            Height = height;
            Weight = weight;
            Allergies = allergies;
            Doctor = doctor;
            Blocked = blocked;
            Malicious = malicious;
            CanceledAppointments = canceledAppointments;
        }
    }
}
