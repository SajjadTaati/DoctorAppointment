using DoctorAppointment.Domain.Entities;
using DoctorAppointment.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Domain.Interfaces.Repositories
{
        public interface IAppointmentRepository
        {
            Task<List<Appointment>> GetByDateAsync(DateTime date);
            Task<List<Appointment>> GetByUserIdAsync(int userId);
            Task<Appointment?> GetByIdAsync(int id);
            Task<bool> ExistsAsync(DateTime date, DateTime timeSlot);
            Task<Appointment> CreateAsync(Appointment appointment);
            Task UpdateAsync(Appointment appointment);
            Task<int> CountAsync(AppointmentStatus? status, DateTime? date);
            Task<List<Appointment>> GetFilteredAsync(
        AppointmentStatus? status,
        DateTime? date,
        int page,
        int pageSize);

        }
}
