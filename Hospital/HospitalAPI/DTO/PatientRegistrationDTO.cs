using Hospital_library.MedicalRecords.Model;
using Hospital_library.MedicalRecords.Model.Enums;
using Hospital_library.Model.Enumeration;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Hospital_API.DTO
{

    public class PatientRegistrationDTO
    {

        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Jmbg { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Gender Gender { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public UserType UserType { get; set; }
        public BloodType BloodType { get; set; }
        public RhFactor RhFactor { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public List<Allergy> Allergies { get; set; }
        public Doctor Doctor { get; set; }
        public string ClientURI { get; set; }

        public PatientRegistrationDTO()
        {

        }
        public PatientRegistrationDTO(string name, string surname, DateTime birthDate,
            string jmbg, string address, string phone, string email, string username,
            string password, Gender gender, string city, string country, UserType userType,
            BloodType bloodType, RhFactor rhfactor, int height, int weight, List<Allergy> allergies,
            Doctor doctor, string clientUrl)
        {
            Name = name;
            Surname = surname;
            BirthDate = birthDate;
            Jmbg = jmbg;
            Address = address;
            Phone = phone;
            Email = email;
            Username = username;
            Password = password;
            Gender = gender;
            City = city;
            Country = country;
            UserType = userType;
            BloodType = bloodType;
            RhFactor = rhfactor;
            Height = height;
            Weight = weight;
            Allergies = allergies;
            Doctor = doctor;
            ClientURI = clientUrl;
        }
    }
}
