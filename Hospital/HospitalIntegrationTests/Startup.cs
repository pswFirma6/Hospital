using AutoMapper;
using HospitalAPI;
using HospitalAPI.ImplRepository;
using HospitalAPI.ImplService;
using HospitalAPI.Repository;
using HospitalAPI.Validation;
using HospitalLibrary.MedicalRecords.Model;
using HospitalLibrary.MedicalRecords.Repository.Repository.Interface;
using HospitalLibrary.MedicalRecords.Service;
using HospitalLibrary.MedicalRecords.Model.Enums;
using HospitalLibrary.Model.Enums;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using static HospitalAPI.Mapper.Mapper;
using System.Collections.Generic;
using HospitalAPI.Service;
using Hospital_library.MedicalRecords.Service;
using HospitalLibraryHospital_library.MedicalRecords.Repository;

namespace HospitalIntegrationTests
{
    public class Startup
    {
        [Obsolete]
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


            services.AddIdentity<PatientRegistration, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = false;
            })
             .AddEntityFrameworkStores<MyDbContext>()
             .AddDefaultTokenProviders(); 


            // Registration 
            var emailConfig = Configuration
               .GetSection("EmailConfiguration")
               .Get<EmailConfiguration>();
            services.AddSingleton(emailConfig);
            services.AddScoped<IEmailSender, EmailSender>();

            // The AddScoped method registers the service with a scoped lifetime, the lifetime of a single request
            services.AddScoped<IRegistrationService,RegistrationService>();
            services.AddScoped<IPatientService,PatientService>();
            services.AddScoped<IFeedbackService, FeedbackService>();
            services.AddScoped<ISurveyService, SurveyService>();
            services.AddScoped<IAppointmentService, AppointmentService>();
            services.AddScoped<IDoctorService, DoctorService>();

            // Validation
            services.AddScoped<RegistrationValidation>();
            services.AddScoped<SurveyValidation>();
            services.AddScoped<AppointmentValidation>();

            // Repository
            services.AddScoped<RepositoryFactory, HospitalRepositoryFactory>();
            services.AddScoped<IPatientRepository, PatientRepository>();

            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            services.AddDbContext<MyDbContext>(options =>
            {
                options.UseInMemoryDatabase("InMemoryDbForTesting").UseLazyLoadingProxies();
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
                    catch (Exception)
                    {
                        throw;
                    }
            }
        }

    
        public static void InitializeDbForTests(MyDbContext db)
        {
            AddTestDoctor(db);
            CreatePatients(db);
            db.SaveChanges();
        }

        // In Memory DB for tests
        private static void AddTestDoctor(MyDbContext context)
        {
            //  Add fake data

            List<Patient> patients = new List<Patient>();
            List<Appointment> appointments = new List<Appointment>();
            var dateString = "2/12/2022 8:30:00 AM";
            DateTime date = DateTime.Parse(dateString,
                          System.Globalization.CultureInfo.InvariantCulture);

            Doctor doctor = new Doctor( 1, "Mirko", "Mirkovic", date, "9981902895421", "Jase Tomic 44."
                    , "0645796684", "drmirkovic@bch.com", "Dr Mirko", "Mirko123", Gender.male
                    , "Novi Sad", "Serbia", UserType.doctor, patients, DoctorType.allergy_and_immunology, appointments);

            context.Add(doctor);
        }

        public static void CreatePatients(MyDbContext db)
        {
            List<Patient> listOfPatients = new List<Patient>();
           
            List<Allergy> allergies = new List<Allergy>();

            var doctor = db.Doctors.Find(1);

            Patient newPatientA1 = new Patient(2, "Slavko", "Vranjes", DateTime.Now,
                "054236971333", "Partizanskih baza 8.", "0666423699", "slavko@gmail.com",
                "slavko", "slavko123", Gender.male,
                "Novi Sad", "Serbia", UserType.patient, BloodType.B, RhFactor.positive,
                189, 85, allergies, doctor);


            Patient newPatientB2 = new Patient(3, "Marko", "Markovic", DateTime.Now,
                "0542369712588", "Partizanskih baza 7.", "0666423599", "marko@gmail.com",
                "SeekEquilibrium", "marko123", Gender.female,
                "Novi Sad", "Serbia", UserType.patient, BloodType.A, RhFactor.negative,
                180, 85, allergies, doctor);

            db.Patients.Add(newPatientA1);
            db.Patients.Add(newPatientB2);

            
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
