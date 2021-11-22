using AutoMapper;
using Hospital.Service;
using Hospital_API;
using Hospital_API.ImplRepository;
using Hospital_API.ImplService;
using Hospital_API.Repository;
using Hospital_API.Validation;
using Hospital_library.MedicalRecords.Repository.Repository.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using static Hospital_API.Mapper.FeedbackMapper;
using static Hospital_API.Mapper.PatientMapper;

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
            services.AddMvc().AddApplicationPart(Assembly.Load(new AssemblyName("Hospital API"))); //"HospitalAPI" is your original project name

            // Auto Mapper Configurations
            var mapperConfigFeedback = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new FeedbackMappingProfile());
            });

            IMapper mapperFeedback = mapperConfigFeedback.CreateMapper();
            services.AddSingleton(mapperFeedback);

            var mapperConfigPatient = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new PatientMappingProfile());
            });

            IMapper mapperPatient = mapperConfigPatient.CreateMapper();
            services.AddSingleton(mapperPatient);

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
