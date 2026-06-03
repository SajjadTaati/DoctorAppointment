using DoctorAppointment.Domain.Entities;
using DoctorAppointment.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

                                                         

namespace DoctorAppointment.Infrastructure.Persistence.Repositories
{


    public class WorkingHourRepository : IWorkingHourRepository
    {
        private readonly AppDbContext _db; // تعریف فیلد خصوصی

        // constructor کلاسیک
        public WorkingHourRepository(AppDbContext db)
        {
            _db = db; // مقداردهی فیلد خصوصی
        }

        public async Task<WorkingHour?> ReplaceAllAsync(DayOfWeek day) =>
            await _db.WorkingHours.FirstOrDefaultAsync(w => w.DayOfWeek == day); // حالا از _db استفاده کن

        public async Task<List<WorkingHour>> GetAllAsync() =>
            await _db.WorkingHours.ToListAsync(); // حالا از _db استفاده کن

        public Task ReplaceAllAsync(List<WorkingHour> workingHours)
        {
            // اینجا باید پیاده‌سازی واقعی متد رو بنویسی
            // مثلاً:
            // _db.WorkingHours.RemoveRange(_db.WorkingHours.Where(wh => wh.Day == workingHours.First().Day));
            // await _db.WorkingHours.AddRangeAsync(workingHours);
            // await _db.SaveChangesAsync();
            throw new NotImplementedException(); // فعلاً نگهش دار تا کاملش کنی
        }
    }

}
