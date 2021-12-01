using AutoMapper;
using Hospital_library.MedicalRecords.Service;
using HospitalAPI.EditorService;
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
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using static HospitalAPI.Mapper.Mapper;

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
                        builder.WithOrigins("http://localhost:4200")
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


            services.AddScoped<BuildingService>();
            services.AddScoped<EquipmentService>();
            services.AddScoped<FloorService>();
            services.AddScoped<RoomService>();

            // Need to AddScoped for every dependency injection validation
            services.AddScoped<FeedbackValidation>();
            services.AddScoped<RegistrationValidation>();

            // Repository dependency injection
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddScoped<SurveyService>();

           
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
                    options.UseNpgsql(Configuration.GetConnectionString("MyDbContextConnectionString")).UseLazyLoadingProxies());
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
    }
}
