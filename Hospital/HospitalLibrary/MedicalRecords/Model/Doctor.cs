using Hospital_library.MedicalRecords.Model.Enums;
using Hospital_library.Model.Enumeration;
using System;
using System.Collections.Generic;

namespace HospitalLibrary.MedicalRecords.Model
{
    public class Doctor : User
    {
        public List<Patient> Patients { get; set; }
        public DoctorType DoctorType { get; set; }
        public List<Appointment> Appointments { get; set; }

        public Doctor()
        {
        }
        public Doctor(string id, string name, string surname, DateTime birthDate, string jmbg, string address, string phone, string email, string username, string password, Gender gender, string city, string country, UserType userType, List<Patient> patients, DoctorType doctorType, List<Appointment> appointments)
            : base(id, name, surname, birthDate, jmbg, address, phone, email, username, password, gender, city, country, userType)
        {
            Patients = patients;
            DoctorType = doctorType;
            Appointments = appointments;
        }
    }
}
