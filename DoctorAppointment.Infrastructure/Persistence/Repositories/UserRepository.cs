using DoctorAppointment.Domain.Entities;
using DoctorAppointment.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Infrastructure.Persistence.Repositories
{
    public class UserRepository(AppDbContext db) : IUserRepository
    {
        public async Task<User?> GetByPhoneAsync(string phone) =>
            await db.Users.FirstOrDefaultAsync(u => u.Phone == phone);

        public async Task<User?> GetByIdAsync(int id) =>
            await db.Users.FindAsync(id);

        public async Task<User> CreateAsync(User user)
        {
            db.Users.Add(user);
            await db.SaveChangesAsync();
            return user;
        }

        public async Task UpdateAsync(User user)
        {
            db.Users.Update(user);
            await db.SaveChangesAsync();
        }
    }

}
