using DoctorAppointment.Application.Common;
using DoctorAppointment.Application.DTOs.Admin;
using DoctorAppointment.Application.DTOs.Appointment;
using DoctorAppointment.Domain.Enums;
using DoctorAppointment.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Application.UseCases.Admin
{
    public class GetAppointmentsUseCase(IAppointmentRepository appointmentRepo)
    {
        public async Task<Result<PagedResult<AppointmentDto>>> ExecuteAsync(
            string? status, DateOnly? date, int page, int pageSize)
        {
            AppointmentStatus? parsedStatus = status is not null
                ? Enum.Parse<AppointmentStatus>(status, true)
                : null;

            var items = await appointmentRepo.GetAllAsync(parsedStatus, date, page, pageSize);
            var total = await appointmentRepo.CountAsync(parsedStatus, date);

            var dtos = items.Select(a => new AppointmentDto(
                a.Id, 
                a.Date, 
                a.TimeSlot, a.Status.ToString(),
                a.User?.Phone, a.User?.Name, a.Date)).ToList();

            return Result<PagedResult<AppointmentDto>>.Success(new PagedResult<AppointmentDto>(total, dtos));
        }
    }
}
