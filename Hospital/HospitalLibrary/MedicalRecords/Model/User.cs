using HospitalLibrary.MedicalRecords.Model.Enums;
using HospitalLibrary.Model.Enums;
using System;

namespace HospitalLibrary.MedicalRecords.Model
{
    public class User : Entity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
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
        public bool Activated { get; set; }

        public User() 
        {
        }
        public User(int id, string name, string surname, DateTime birthDate, string jmbg, string address, string phone, string email, string username, string password, Gender gender, string city, string country, UserType userType)
        {
            Id = id;
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
        }
        public User(int id, string name, string surname, 
            DateTime birthDate, string jmbg, string address, string phone, string email, 
            string username, string password, Gender gender, string city, string country, 
            UserType userType, bool activated)
        {
            Id = id;
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
            Activated = activated;
        }

        public User(string username, string password, UserType userType) 
        {
            Username = username;
            Password = password;
            UserType = userType;
        }
    }
}
