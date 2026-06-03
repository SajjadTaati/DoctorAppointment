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
        Task<List<Appointment>> GetByDateAsync(DateOnly date);
        Task<List<Appointment>> GetByUserIdAsync(int userId);
        Task<Appointment?> GetByIdAsync(int id);
        Task<bool> ExistsAsync(DateOnly date, TimeSpan timeSlot);
        Task<Appointment> CreateAsync(Appointment appointment);
        Task UpdateAsync(Appointment appointment);
        Task<List<Appointment>> GetAllAsync(AppointmentStatus? status, DateOnly? date, int page, int pageSize);
        Task<int> CountAsync(AppointmentStatus? status, DateOnly? date);
    }
}
