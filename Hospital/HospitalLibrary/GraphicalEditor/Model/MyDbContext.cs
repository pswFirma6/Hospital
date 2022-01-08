using Microsoft.EntityFrameworkCore;
using HospitalLibrary.GraphicalEditor.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalLibrary.GraphicalEditor.Model
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

            optionsBuilder.UseNpgsql(CreateConnectionStringFromEnvironment());
        }

        private static string CreateConnectionStringFromEnvironment()
        {
            var server = Environment.GetEnvironmentVariable("DATABASE_HOST") ?? "localhost";
            var port = Environment.GetEnvironmentVariable("DATABASE_PORT") ?? "5432";
            var database = Environment.GetEnvironmentVariable("DATABASE_SCHEMA") ?? "hospitaldb";
            var user = Environment.GetEnvironmentVariable("DATABASE_USERNAME") ?? "root";
            var password = Environment.GetEnvironmentVariable("DATABASE_PASSWORD") ?? "root";
            var integratedSecurity = Environment.GetEnvironmentVariable("DATABASE_INTEGRATED_SECURITY") ?? "true";
            var pooling = Environment.GetEnvironmentVariable("DATABASE_POOLING") ?? "true";

            string retVal = "Server=" + server + ";Port=" + port + ";Database=" + database + ";User ID=" + user + ";Password=" + password + ";Integrated Security=" + integratedSecurity + ";Pooling=" + pooling + ";";
            return retVal;
        }
    }
}
