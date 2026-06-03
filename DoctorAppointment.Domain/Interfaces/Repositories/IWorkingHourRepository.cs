using DoctorAppointment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Domain.Interfaces.Repositories
{
    public interface IWorkingHourRepository
    {
        Task<List<WorkingHour>> GetAllAsync();
        Task ReplaceAllAsync(List<WorkingHour> workingHours);
    }
}
