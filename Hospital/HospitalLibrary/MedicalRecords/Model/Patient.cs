using HospitalLibrary.MedicalRecords.Model.Enums;
using HospitalLibrary.Model.Enums;
using System;
using System.Collections.Generic;

namespace HospitalLibrary.MedicalRecords.Model
{
    public class Patient : User
    {
        public virtual MedicalRecord Record { get; set; }
        public virtual ICollection<Allergy> Allergies { get; set; }
        public int DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }
        public bool Blocked { get; set; }
        public bool Malicious { get; set; }

        public Patient() 
        {
        }
        public Patient(int id, string name, string surname, DateTime birthDate, 
            string jmbg, string address, string phone, string email, string username, 
            string password, Gender gender, string city, string country, UserType userType, 
            BloodType bloodType, RhFactor rhfactor, int height, int weight, List<Allergy> allergies, 
            Doctor doctor)
            : base(id, name, surname, birthDate, jmbg, address, phone, email, username, 
                  password, gender, city, country, userType)
        {
            Record = new MedicalRecord(id,bloodType, rhfactor, height, weight);
            Allergies = allergies;
            Doctor = doctor;   
        }
        public Patient(int id, string name, string surname, DateTime birthDate,
        string jmbg, string address, string phone, string email, string username,
        string password, Gender gender, string city, string country, UserType userType, bool activated,
        BloodType bloodType, RhFactor rhfactor, int height, int weight, List<Allergy> allergies,
        Doctor doctor)
        : base(id, name, surname, birthDate, jmbg, address, phone, email, username,
          password, gender, city, country, userType, activated)
        {
            Record = new MedicalRecord(id,bloodType, rhfactor, height, weight);
            Allergies = allergies;
            Doctor = doctor;
        }
    }
}
