using DoctorAppointment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Domain.Interfaces.Repositories
{
    public interface IHolidayRepository
    {
        Task<List<Holiday>> GetAllAsync();
        Task<bool> IsHolidayAsync(DateOnly date);
        Task<Holiday> CreateAsync(Holiday holiday);
        Task DeleteAsync(int id);
    }
}
