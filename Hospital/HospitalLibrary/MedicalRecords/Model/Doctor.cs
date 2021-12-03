﻿using HospitalLibrary.MedicalRecords.Model.Enums;
using HospitalLibrary.Model;
using HospitalLibrary.Model.Enumeration;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary.MedicalRecords.Model
{
    public class Doctor : User
    {
        public Doctor()
        {

        }
        public Doctor(string id, string name, string surname, DateTime birthDate, string jmbg, string address, string phone, string email, string username, string password, Gender gender, string city, string country, UserType userType)
            : base(id, name, surname, birthDate, jmbg, address, phone, email, username, password, gender, city, country, userType)
        {
        
        }
        public Doctor( string name , string surname)
        {
            Name = name;
            Surname = surname;
        }
    }
}
