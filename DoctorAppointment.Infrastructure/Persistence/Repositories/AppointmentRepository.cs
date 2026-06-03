using DoctorAppointment.Domain.Entities;
using DoctorAppointment.Domain.Enums;
using DoctorAppointment.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
namespace DoctorAppointment.Infrastructure.Persistence.Repositories
{

    public class AppointmentRepository(AppDbContext db) : IAppointmentRepository
    {
        public async Task<List<Appointment>> GetByDateAsync(DateTime date) =>
            await db.Appointments.Where(a => a.Date == date).ToListAsync();

        public async Task<Appointment?> GetByIdAsync(int id) =>
            await db.Appointments.FindAsync(id);

        // نوع داده userId باید با اینترفیس یکی باشد (اینجا int فرض شده، اگر Guid است باید اینترفیس را تغییر دهید)
        public async Task<List<Appointment>> GetByUserIdAsync(int userId) =>
            await db.Appointments.Where(a => a.UserId == userId).ToListAsync();

        public async Task<Appointment> CreateAsync(Appointment appointment)
        {
            db.Appointments.Add(appointment);
            await db.SaveChangesAsync();
            return appointment; // باید آبجکت ساخته شده را برگرداند
        }

        public async Task UpdateAsync(Appointment appointment)
        {
            db.Appointments.Update(appointment);
            await db.SaveChangesAsync();
        }

        // تغییر پارامترها مطابق اینترفیس
        public async Task<int> CountAsync(AppointmentStatus? status, DateTime? date)
        {
            var query = db.Appointments.AsQueryable();

            if (status.HasValue)
                query = query.Where(a => a.Status == status.Value);

            if (date.HasValue)
                query = query.Where(a => a.Date == date.Value);

            return await query.CountAsync();
        }

        // تغییر پارامترها مطابق اینترفیس
        public async Task<bool> ExistsAsync(DateTime date, DateTime timeSlot) =>
            await db.Appointments.AnyAsync(a => a.Date == date && a.Date == timeSlot); // فرض بر این است که پراپرتی Time دارید

        public async Task<List<Appointment>> GetFilteredAsync(
            AppointmentStatus? status,
            DateTime? date,
            int page,
            int pageSize)
        {
            var query = db.Appointments.Include(a => a.User).AsQueryable();

            if (status.HasValue)
                query = query.Where(a => a.Status == status.Value);

            if (date.HasValue)
                query = query.Where(a => a.Date == date.Value);

            return await query
                .OrderByDescending(a => a.Date)
                .ThenByDescending(a => a.Date) // دقت کنید پراپرتی Time در مدل شما وجود داشته باشد
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
    }



}
