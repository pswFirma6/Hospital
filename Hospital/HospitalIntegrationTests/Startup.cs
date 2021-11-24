using AutoMapper;
using Hospital.Service;
using Hospital_API;
using Hospital_API.ImplRepository;
using Hospital_API.ImplService;
using Hospital_API.Repository;
using Hospital_API.Validation;
using Hospital_library.MedicalRecords.Model;
using Hospital_library.MedicalRecords.Repository.Repository.Interface;
using Hospital_library.MedicalRecords.Service;
using HospitalAPI.ImplService;
using HospitalLibrary.MedicalRecords.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using static Hospital_API.Mapper.Mapper;

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

            // Validation
            services.AddScoped<RegistrationValidation>();

            services.AddScoped<HospitalRepositoryFactory>();
            services.AddScoped<IPatientRepository, PatientRepository>();

            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            services.AddDbContext<MyDbContext>(options =>
            {
                options.UseInMemoryDatabase("InMemoryDbForTesting");
            });
            
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
