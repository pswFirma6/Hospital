using Microsoft.EntityFrameworkCore;
using project.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project.Model
{
    public class MyDbContext : DbContext
    {
        public static ProjectConfiguration Configuration;

        public MyDbContext(DbContextOptions<MyDbContext> context, ProjectConfiguration configuration) : base(context)
        {
            if (configuration != null)
            {
                MyDbContext.Configuration = configuration;
            }
        }

        public MyDbContext()
        {
        }

        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Floor> Floors { get; set; }
        public DbSet<Building> Buildings { get; set; }




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
            {
                return;
            }

            optionsBuilder.UseNpgsql("Server=localhost; Port =5432; Database = editorsdb; User Id = postgres; Password =loki123;");
        }
    }
}
