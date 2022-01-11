using HospitalLibrary.MedicalRecords.Model;
using HospitalLibrary.MedicalRecords.Model.Enums;
using HospitalLibrary.Model.Enums;
using System;

namespace Hospital_library.MedicalRecords.Model
{
    public class Manager : User
    {
        public Manager()
        {
        }
        public Manager(int id, string name, string surname, DateTime birthDate,
            string jmbg, string address, string phone, string email, string username,
            string password, Gender gender, string city, string country, UserType userType)
            : base(id, name, surname, birthDate, jmbg, address, phone, email, username,
                  password, gender, city, country, userType)
        {
        }

    }
}
