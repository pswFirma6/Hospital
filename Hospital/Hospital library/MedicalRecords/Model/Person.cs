using Hospital_library.MedicalRecords.Model;
using Hospital_library.Model.Enumeration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_library.Model
{
    public class Person : Entity
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
        public Gender gender { get; set; }

        public Person(string id,string name, string surname, DateTime birthDate, string jmbg, string address, string phone, string email, string username, string password, Gender gender)
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
            this.gender = gender;
        }
    }
}
