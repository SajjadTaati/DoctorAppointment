using DoctorAppointment.Application.Common;
using DoctorAppointment.Application.DTOs.Appointment;
using DoctorAppointment.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Application.UseCases.Appointment
{
    public class GetUserAppointmentsUseCase(IAppointmentRepository appointmentRepo)
    {
        public async Task<Result<List<AppointmentDto>>> ExecuteAsync(int userId)
        {
            var list = await appointmentRepo.GetByUserIdAsync(userId);
            var result = list.Select(a => new AppointmentDto(
                a.Id, a.Date, a.TimeSlot, a.Status.ToString(),
                a.User?.Phone, a.User?.Name, a.Date)).ToList();

            return Result<List<AppointmentDto>>.Success(result);
        }
    }
}
