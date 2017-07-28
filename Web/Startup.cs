using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Repository.DAL;
using Repository.Dto;
using Repository.Repositories.Implementations;
using Repository.Repositories.Interfaces;
using Service.Services.Implementations;
using Service.Services.Interfaces;
using Service.Services.Mappers;

namespace Web
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.

            services.AddDbContext<ApplicationDbContext>(
                o => o.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddTransient<IPatientService, PatienceService>();
            services.AddTransient<IPatientRepository, PatientRepository>();
            services.AddTransient<IMapper<Patient, PatientDto>, PatientMapper>();
            services.AddTransient<IMapper<Doctor, DoctorDto>, DoctorMapper>();
            services.AddTransient<IMapper<Order, OrderDto>, OrderMapper>();
            services.AddTransient<IMapper<Stay, StayDto>, StayMapper>();
            services.AddTransient<IMapper<Test, TestDto>, TestMapper>();
            services.AddTransient<IDoctorService, DoctorService>();
            services.AddTransient<IDoctorRepository, DoctorRepository>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IStayService, StayService>();
            services.AddTransient<IStayRepository, StayRepository>();
            services.AddTransient<ITestService, TestService>();
            services.AddTransient<ITestRepository, TestRepository>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();

            //DbInitializer.Initialize(db);
        }
    }
}
