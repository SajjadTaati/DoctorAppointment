using DoctorAppointment.Domain.Interfaces.Repositories;
using DoctorAppointment.Domain.Services;
using DoctorAppointment.Infrastructure.Persistence;
using DoctorAppointment.Infrastructure.Persistence.Repositories;
using DoctorAppointment.Infrastructure.Persistence.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Infrastructure
{
    // Infrastructure/DependencyInjection.cs
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<AppDbContext>(opt =>
                opt.UseSqlServer(config.GetConnectionString("Default")));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            services.AddScoped<IWorkingHourRepository, WorkingHourRepository>();
            services.AddScoped<IHolidayRepository, HolidayRepository>();
            services.AddScoped<IAdminRepository, AdminRepository>();

           // services.AddScoped<ISmsService, SmsService>();
            services.AddScoped<IJwtService, JwtService>();

            return services;
        }
    }

}
