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
    public class AdminRepository(AppDbContext db) : IAdminRepository
    {
        public async Task<Admin?> GetByUsernameAsync(string username) =>
            await db.Admins.FirstOrDefaultAsync(a => a.Username == username);
    }
}
