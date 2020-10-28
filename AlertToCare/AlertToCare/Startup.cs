using AlertToCare.BusinessLogic;
using AlertToCare.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using DbContext = AlertToCare.Repository.DbContext;
using System.Diagnostics.CodeAnalysis;

namespace AlertToCare
{
    [ExcludeFromCodeCoverage]
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime.
        //Use this method to add services to the container.
        [System.Obsolete]
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins, builder =>
                 {
                     builder.AllowAnyOrigin();
                     builder.AllowAnyHeader();
                     builder.AllowAnyMethod();
                 });
            });

            services.AddDbContext<DbContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        
        services.AddControllers();
            //Once instance of type PatientMemoryDBRepository created - Any number of Resolve request
            services.AddTransient<IPatientBusinessLogic, PatientBusinessLogic>();
            services.AddTransient<IIcuLayoutBusinessLogic, IcuLayoutBusinessLogic>();
            services.AddTransient<IMedicalDeviceBusinessLogic, MedicalDeviceBusinessLogic>();
            services.AddTransient<IPatientDataRepository, PatientDataRepository>();
            services.AddTransient<IMedicalDeviceDataRepository, MedicalDeviceDataRepository>();
            services.AddTransient<IIcuLayoutDataRepository, IcuLayoutDataRepository>();
            services.AddTransient<INurseBusinessLogic, NurseBusinessLogic>();
            services.AddTransient<INurseDataRepository, NurseDataRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(MyAllowSpecificOrigins);

            app.UseRouting();

            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}