using Hospital_library.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Linq;

namespace Hospital_API
{
    public class MyDbContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }   
    }
}
