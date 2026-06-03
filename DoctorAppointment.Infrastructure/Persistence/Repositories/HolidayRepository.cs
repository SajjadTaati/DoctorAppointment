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
    using Microsoft.EntityFrameworkCore;

    public class HolidayRepository(AppDbContext db) : IHolidayRepository
    {
        // ۱. اضافه شدن متد GetAllAsync
        public async Task<List<Holiday>> GetAllAsync()
        {
            return await db.Holidays.ToListAsync();
        }

        public async Task<bool> IsHolidayAsync(DateOnly date) =>
            await db.Holidays.AnyAsync(h => h.Date == date);

        public async Task<Holiday> CreateAsync(Holiday holiday)
        {
            db.Holidays.Add(holiday);
            await db.SaveChangesAsync();

            // ۲. برگرداندن شیء ذخیره شده برای تطابق با Task<Holiday>
            return holiday;
        }

        // ۳. اضافه شدن متد DeleteAsync
        public async Task DeleteAsync(int id)
        {
            var holiday = await db.Holidays.FindAsync(id);
            if (holiday != null)
            {
                db.Holidays.Remove(holiday);
                await db.SaveChangesAsync();
            }
        }
    }

}
