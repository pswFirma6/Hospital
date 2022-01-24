using Hospital_library.MedicalRecords.Model.Events;
using Microsoft.EntityFrameworkCore;


namespace HospitalAPI
{
    public class DatabaseEventContext : DbContext
    {

        public DbSet<AppointmentEvent> AppointmentEvents { get; set; }
        public DbSet<EventStep> StepEvents { get; set; }

        public DatabaseEventContext(DbContextOptions<DatabaseEventContext> options) : base(options) { }
     
    }
}
