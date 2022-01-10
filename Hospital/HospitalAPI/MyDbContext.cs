﻿﻿using Hospital_library.MedicalRecords.Model;
using HospitalLibrary.MedicalRecords.Model;
using Microsoft.EntityFrameworkCore;

namespace HospitalAPI
{
    public class MyDbContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Allergy> Allergies { get; set; }
        public DbSet<SurveyQuestion> SurveyQuestion { get; set; }
        public DbSet<Appointment> Appointments {get ; set ;}
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Manager> Managers { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

    }
}
