using HospitalLibrary.MedicalRecords.Model.Enums;
using HospitalLibrary.Model.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace HospitalLibrary.MedicalRecords.Model
{
    public class PatientRegistration : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
     
        public string Username { get; set; }
        public string Password { get; set; }
        public UserType UserType { get; set; }
        public string ClientURI { get; set; }

    }
}
