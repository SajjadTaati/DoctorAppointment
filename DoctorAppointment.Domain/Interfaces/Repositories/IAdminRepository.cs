using DoctorAppointment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Domain.Interfaces.Repositories
{
    public interface IAdminRepository
    {
        Task<Admin?> GetByUsernameAsync(string username);
    }
}
