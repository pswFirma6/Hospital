using HospitalLibrary.MedicalRecords.Model;
using HospitalLibrary.Model;
using Microsoft.EntityFrameworkCore;

namespace HospitalAPI
{
    public class MyDbContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }   
    }
}
