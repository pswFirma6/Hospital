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
using Hospital_library.MedicalRecords.Service.Interfaces;
using Hospital_library.MedicalRecords.Service.Implements;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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


            services.AddIdentity<PatientRegistration, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = false;
            })
             .AddEntityFrameworkStores<MyDbContext>()
             .AddDefaultTokenProviders();

            // Security 
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["Jwt:Issuer"],
                    ValidAudience = Configuration["Jwt:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                };
            });

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
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IEventService, EventService>();

            // Validation
            services.AddScoped<RegistrationValidation>();
            services.AddScoped<SurveyValidation>();
            services.AddScoped<AppointmentValidation>();
            services.AddScoped<LoginValidation>();
            services.AddScoped<EventValidation>();

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
            CreatePatients(db);
            AddTestDoctor(db);
            db.SaveChanges();
        }

        // In Memory DB for tests
        private static void AddTestDoctor(MyDbContext context)
        {
            //  Add fake data

            List<Patient> patients = new List<Patient>();

            var patient = context.Patients.Find(2);

            var dateString = "2/12/2022 8:30:00 AM";
            DateTime date = DateTime.Parse(dateString,
                          System.Globalization.CultureInfo.InvariantCulture);

            //appointments
            Doctor doc = new Doctor();

            var dateString1 = "12/01/2022 7:00:00 AM";
            DateTime date1 = DateTime.Parse(dateString1,
                                      System.Globalization.CultureInfo.InvariantCulture);
            Appointment appointment1 = new Appointment(date1, patient.Id, patient, 1, doc);

            var dateString2 = "12/01/2022 7:30:00 AM";
            DateTime date2 = DateTime.Parse(dateString2,
                                      System.Globalization.CultureInfo.InvariantCulture);
            Appointment appointment2 = new Appointment(date2, patient.Id, patient, 1, doc);

            var dateString3 = "12/01/2022 8:00:00 AM";
            DateTime date3 = DateTime.Parse(dateString3,
                                      System.Globalization.CultureInfo.InvariantCulture);
            Appointment appointment3 = new Appointment(date3, patient.Id, patient, 1, doc);

            var dateString4 = "12/01/2022 8:30:00 AM";
            DateTime date4 = DateTime.Parse(dateString4,
                                      System.Globalization.CultureInfo.InvariantCulture);
            Appointment appointment4 = new Appointment(date4, patient.Id, patient, 1, doc);

            var dateString5 = "12/01/2022 9:00:00 AM";
            DateTime date5 = DateTime.Parse(dateString5,
                                      System.Globalization.CultureInfo.InvariantCulture);
            Appointment appointment5 = new Appointment(date5, patient.Id, patient, 1, doc);

            var dateString6 = "12/01/2022 9:30:00 AM";
            DateTime date6 = DateTime.Parse(dateString6,
                                      System.Globalization.CultureInfo.InvariantCulture);
            Appointment appointment6 = new Appointment(date6, patient.Id, patient, 1, doc);

            var dateString7 = "12/01/2022 10:00:00 AM";
            DateTime date7 = DateTime.Parse(dateString7,
                                      System.Globalization.CultureInfo.InvariantCulture);
            Appointment appointment7 = new Appointment(date7, patient.Id, patient, 1, doc);

            var dateString8 = "12/01/2022 10:30:00 AM";
            DateTime date8 = DateTime.Parse(dateString8,
                                      System.Globalization.CultureInfo.InvariantCulture);
            Appointment appointment8 = new Appointment(date8, patient.Id, patient, 1, doc);

            var dateString9 = "12/01/2022 11:00:00 AM";
            DateTime date9 = DateTime.Parse(dateString9,
                                      System.Globalization.CultureInfo.InvariantCulture);
            Appointment appointment9 = new Appointment(date9, patient.Id, patient, 1, doc);

            var dateString10 = "12/01/2022 11:30:00 AM";
            DateTime date10 = DateTime.Parse(dateString10,
                                      System.Globalization.CultureInfo.InvariantCulture);
            Appointment appointment10 = new Appointment(date10, patient.Id, patient, 1, doc);

            var dateString11 = "12/01/2022 12:00:00 PM";
            DateTime date11 = DateTime.Parse(dateString11,
                                      System.Globalization.CultureInfo.InvariantCulture);
            Appointment appointment11 = new Appointment(date11, patient.Id, patient, 1, doc);

            var dateString12 = "12/01/2022 12:30:00 PM";
            DateTime date12 = DateTime.Parse(dateString12,
                                      System.Globalization.CultureInfo.InvariantCulture);
            Appointment appointment12 = new Appointment(date12, patient.Id, patient, 1, doc);

            var dateString13 = "12/01/2022 01:00:00 PM";
            DateTime date13 = DateTime.Parse(dateString13,
                                      System.Globalization.CultureInfo.InvariantCulture);
            Appointment appointment13 = new Appointment(date13, patient.Id, patient, 1, doc);

            var dateString14 = "12/01/2022 01:30:00 PM";
            DateTime date14 = DateTime.Parse(dateString14,
                                      System.Globalization.CultureInfo.InvariantCulture);
            Appointment appointment14 = new Appointment(date14, patient.Id, patient, 1, doc);

            var dateString15 = "12/01/2022 02:00:00 PM";
            DateTime date15 = DateTime.Parse(dateString15,
                                      System.Globalization.CultureInfo.InvariantCulture);
            Appointment appointment15 = new Appointment(date15, patient.Id, patient, 1, doc);

            var dateString16 = "12/01/2022 02:30:00 PM";
            DateTime date16 = DateTime.Parse(dateString16,
                                      System.Globalization.CultureInfo.InvariantCulture);
            Appointment appointment16 = new Appointment(date16, patient.Id, patient, 1, doc);

            var dateString17 = "12/01/2022 03:00:00 PM";
            DateTime date17 = DateTime.Parse(dateString17,
                                      System.Globalization.CultureInfo.InvariantCulture);
            Appointment appointment17 = new Appointment(date17, patient.Id, patient, 1, doc);

            List<Appointment> Doctor1appointments = new List<Appointment>() {
                appointment1, appointment2,
                appointment3, appointment4,
                appointment5, appointment6,
                appointment7, appointment8,
                appointment9, appointment10,
                appointment11, appointment12,
                appointment13, appointment14,
                appointment15, appointment16,
                appointment17,
            };

            List<Appointment> Doctor2appointments = new List<Appointment>();
            List<Appointment> Doctor3appointments = new List<Appointment>();

            Doctor doctor = new Doctor( 1, "Mirko", "Mirkovic", date, "9981902895421", "Jase Tomic 44."
                    , "0645796684", "drmirkovic@bch.com", "Dr Mirko", "Mirko123", Gender.male
                    , "Novi Sad", "Serbia", UserType.doctor, patients, DoctorType.allergy_and_immunology, Doctor1appointments);

            Doctor doctor2 = new Doctor(2, "Marko", "Markovic", date, "9981902895422", "Jase Tomic 45."
                    , "0635796684", "1drsirkovic@bch.com", "Dr Mirko", "Mirko123", Gender.male
                    , "Novi Sad", "Serbia", UserType.doctor, patients, DoctorType.allergy_and_immunology, Doctor2appointments);

            Doctor doctor3 = new Doctor(3, "Stefan", "Stefanovic", date, "9981902895423", "Jase Tomic 46."
                    , "0635796684", "1drsirkovic@bch.com", "Dr Mirko", "Mirko123", Gender.male
                    , "Novi Sad", "Serbia", UserType.doctor, patients, DoctorType.allergy_and_immunology, Doctor3appointments);

            context.Add(doctor);
            context.Add(doctor2);
            context.Add(doctor3);
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


            Patient newPatientC3 = new Patient(4, "Monika", "Beluci", DateTime.Now,
                "054236971333", "Partizanskih baza 8.", "0666423699", "seve@gmail.com",
                "Monika", "pacijent123", Gender.female,
                "Novi Sad", "Serbia", UserType.patient, true, BloodType.B, RhFactor.positive,
                189, 85, allergies, doctor);    


            db.Patients.Add(newPatientA1);
            db.Patients.Add(newPatientB2);
            db.Patients.Add(newPatientC3);

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
