using AutoMapper;
using Hospital.Service;
using HospitalAPI;
using HospitalAPI.ImplRepository;
using HospitalAPI.ImplService;
using HospitalAPI.Repository;
using HospitalAPI.Validation;
using HospitalLibrary.MedicalRecords.Model;
using HospitalLibrary.MedicalRecords.Model.Enums;
using HospitalLibrary.MedicalRecords.Repository.Repository.Interface;
using HospitalLibrary.Model.Enumeration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using static HospitalAPI.Mapper.Mapper;

namespace HospitalIntegrationTests
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddApplicationPart(Assembly.Load(new AssemblyName("HospitalAPI"))); //"HospitalAPI" is your original project name

            // Auto Mapper Configurations
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddMvc();

            // The AddScoped method registers the service with a scoped lifetime, the lifetime of a single request
            services.AddScoped<FeedbackService>();
            services.AddScoped<PatientService>();

            // Validation
            services.AddScoped<RegistrationValidation>();

            services.AddScoped<HospitalRepositoryFactory>();
            services.AddScoped<IPatientRepository, PatientRepository>();

            services.AddControllers();

            services.AddDbContext<MyDbContext>(options =>
            {
                options.UseInMemoryDatabase("InMemoryDbForTesting");
            });
            var serviceProvider = services.BuildServiceProvider();

            using (var scope = serviceProvider.CreateScope())
            {
                using (var db = scope.ServiceProvider.GetRequiredService<MyDbContext>())
                try
                {
                    
                    
                    db.Database.EnsureCreated();
                    InitializeDbForTests(db);
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        
        public static void InitializeDbForTests(MyDbContext db)
        {
            CreatePatients();
            db.SaveChanges();
        }

        public static List<Patient> CreatePatients()
        {
            List<Patient> listOfPatients = new List<Patient>();
             Doctor doctor = new Doctor();
            doctor.Id = "1";
            List<Allergy> allergies = new List<Allergy>();

            Patient newPatientA1 = new Patient("2", "Slavko", "Vranjes", DateTime.Now,
                "054236971333", "Partizanskih baza 8.", "0666423699", "slavko@gmail.com",
                "slavko", "slavko123", Gender.male,
                "Novi Sad", "Serbia", UserType.patient, BloodType.B, RhFactor.positive,
                189, 85, doctor, allergies);
           

            Patient newPatientB2 = new Patient("3", "Marko", "Markovic", DateTime.Now,
                "0542369712546", "Partizanskih baza 7.", "0666423599", "marko@gmail.com",
                "SeekEquilibrium", "mira123",Gender.female,
                "Novi Sad", "Serbia", UserType.patient, BloodType.A, RhFactor.negative,
                180, 85, doctor, allergies);

            listOfPatients.Add(newPatientA1);
            listOfPatients.Add(newPatientB2);

            return listOfPatients;
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseCors();


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
    
}
