﻿using Hospital_library.MedicalRecords.Model;
using HospitalLibrary.MedicalRecords.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Patient>().OwnsOne(p => p.Record , nav =>
            {
                nav.Property(mdr => mdr.MedRecordId).HasColumnName("MedRecordId");
                nav.Property(mdr => mdr.BloodType).HasColumnName("BloodType");
                nav.Property(mdr => mdr.RhFactor).HasColumnName("RhFactor");
                nav.Property(mdr => mdr.Height).HasColumnName("Height");
                nav.Property(mdr => mdr.Weight).HasColumnName("Weight");

            });

            modelBuilder.Entity<Allergy>().OwnsOne(p => p.Description, nav =>
            {
                nav.Property(mdr => mdr.DescriptionID).HasColumnName("DescId");
                nav.Property(mdr => mdr.Medicine).HasColumnName("Medicine");
                nav.Property(mdr => mdr.ReactionTime).HasColumnName("ReactionTime");
                nav.Property(mdr => mdr.ReactionType).HasColumnName("ReactionType");
                

            });

            modelBuilder.Entity<Prescription>().OwnsOne(p => p.Therapy, nav =>
            {
                nav.Property(mdr => mdr.TherapyStart).HasColumnName("TherapyStart");
                nav.Property(mdr => mdr.TherapyEnd).HasColumnName("TherapyEnd");
                nav.Property(mdr => mdr.Diagnosis).HasColumnName("Diagnosis");
                
            });

            modelBuilder.Entity<Prescription>().OwnsOne(p => p.Dosage, nav =>
            {
                nav.Property(mdr => mdr.Quantity).HasColumnName("Quantity");
                nav.Property(mdr => mdr.PrescriptionDate).HasColumnName("PrescriptionDate");
                nav.Property(mdr => mdr.RecommendedDose).HasColumnName("RecommendedDose");
              
            });

            modelBuilder.Entity<Feedback>().OwnsOne(p => p.Information, nav =>
            {
                nav.Property(mdr => mdr.FdbInfId).HasColumnName("FeedbackId");
                nav.Property(mdr => mdr.Text).HasColumnName("Text");
                nav.Property(mdr => mdr.Date).HasColumnName("Date");
                nav.Property(mdr => mdr.State).HasColumnName("State");
            });

        }
    }
}
