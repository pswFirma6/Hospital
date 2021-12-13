using AutoMapper;
using Hospital_library.MedicalRecords.Service;
using HospitalAPI.ImplRepository;
using HospitalAPI.ImplService;
using HospitalAPI.Repository;
using HospitalAPI.Service;
using HospitalAPI.Validation;
using HospitalLibrary.MedicalRecords.Model;
using HospitalLibrary.MedicalRecords.Repository;
using HospitalLibrary.MedicalRecords.Repository.Interface;
using HospitalLibrary.MedicalRecords.Repository.Repository.Interface;
using HospitalLibrary.MedicalRecords.Service;
using HospitalLibraryHospital_library.MedicalRecords.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using static HospitalAPI.Mapper.Mapper;
using DoctorService = HospitalAPI.ImplService.DoctorService;

namespace HospitalAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Enable CORS
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:4202")
                                            .AllowAnyHeader()
                                            .AllowAnyMethod();
                    });
            });

            // Auto Mapper Configurations
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddMvc();
            

            // The AddScoped method registers the service with a scoped lifetime, the lifetime of a single request

            services.AddScoped<IFeedbackService, FeedbackService>();
            services.AddScoped<IPatientService, PatientService>();
            services.AddScoped<IAllergyService, AllergyService>();
            services.AddScoped<IDoctorService, DoctorService>();
            services.AddScoped<RepositoryFactory, HospitalRepositoryFactory>();
            services.AddScoped<IRegistrationService, RegistrationService>();
            services.AddScoped<ISurveyService, SurveyService>();

            services.AddScoped<IAppointmentService, AppointmentService>();

            services.AddScoped<IMedicineService, MedicineService>();
            services.AddScoped<IPrescriptionService, PrescriptionService>();

            services.AddScoped<IAppointmentService, AppointmentService>();

            // Need to AddScoped for every dependency injection validation
            services.AddScoped<FeedbackValidation>();
            services.AddScoped<RegistrationValidation>();
            services.AddScoped<AppointmentValidation>();

            // Repository dependency injection
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

           
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

            // Repository
            services.AddScoped<HospitalRepositoryFactory>();
            services.AddScoped<IPatientRepository, PatientRepository>();

            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            ); 

            // Connection with PostgreSQL

            services.AddDbContext<MyDbContext>(options => 
                    options.UseNpgsql(CreateConnectionStringFromEnvironment()).UseLazyLoadingProxies());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
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
