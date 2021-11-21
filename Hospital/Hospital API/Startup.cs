using AutoMapper;
using Hospital_API.ImplRepository;
using Hospital_API.ImplService;
using Hospital_API.Repository;
using Hospital_API.Service;
using Hospital_library.MedicalRecords.Repository;
using Hospital_library.MedicalRecords.Repository.Interface;
using Hospital_library.MedicalRecords.Repository.Repository.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using static Hospital_API.Mapper.FeedbackMapper;

namespace Hospital_API
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
            services.AddScoped<FeedbackService>();
            services.AddScoped<PatientService>();

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddScoped<SurveyService>();

            services.AddScoped<HospitalRepositoryFactory>();
            services.AddScoped<IPatientRepository, PatientRepository>();
            // Connection with PostgreSQL
            services.AddControllers();

            services.AddDbContext<MyDbContext>(options => 
                    options.UseNpgsql(Configuration.GetConnectionString("MyDbContextConnectionString")));
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
