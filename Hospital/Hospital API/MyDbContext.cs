using Hospital_library.MedicalRecords.Model;
using Hospital_library.Model;
using Microsoft.EntityFrameworkCore;

namespace Hospital_API
{
    public class MyDbContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }   
    }
}
