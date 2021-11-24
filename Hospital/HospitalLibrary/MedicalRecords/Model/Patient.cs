using Hospital_library.MedicalRecords.Model.Enums;
using Hospital_library.Model;
using Hospital_library.Model.Enumeration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital_library.MedicalRecords.Model
{
    public class Patient : User
    {
        public BloodType BloodType { get; set; }
        public RhFactor RhFactor { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public List<Allergy> Allergies { get; set; }
        public Doctor Doctor { get; set; }

        public Patient() 
        {
        }
        public Patient(string id, string name, string surname, DateTime birthDate, string jmbg, string address, string phone, string email, string username, string password, Gender gender, string city, string country, UserType userType, BloodType bloodType, RhFactor rhfactor, int height, int weight, List<Allergy> allergies, Doctor doctor)
            : base(id, name, surname, birthDate, jmbg, address, phone, email, username, password, gender, city, country, userType)
        {
            BloodType = bloodType;
            RhFactor = rhfactor;
            Height = height;
            Weight = weight;
            Allergies = allergies;
            Doctor = doctor;   
        }
    }
}
