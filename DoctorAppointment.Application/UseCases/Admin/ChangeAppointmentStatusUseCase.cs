using DoctorAppointment.Application.Common;
using DoctorAppointment.Domain.Enums;
using DoctorAppointment.Domain.Interfaces.Repositories;
using DoctorAppointment.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Application.UseCases.Admin
{
    public class ChangeAppointmentStatusUseCase(
     IAppointmentRepository appointmentRepo,
     IUserRepository userRepo,
     ISmsService sms)
    {
        public async Task<Result<string>> ExecuteAsync(int appointmentId, string newStatus)
        {
            var appointment = await appointmentRepo.GetByIdAsync(appointmentId);
            if (appointment is null) return Result<string>.Failure("نوبت یافت نشد");

            if (!Enum.TryParse<AppointmentStatus>(newStatus, true, out var status))
                return Result<string>.Failure("وضعیت نامعتبر است");

            appointment.Status = status;
            await appointmentRepo.UpdateAsync(appointment);

            var user = await userRepo.GetByIdAsync(appointment.UserId);
            if (user is not null)
                await sms.SendStatusChangeAsync(user.Phone, newStatus);

            return Result<string>.Success("وضعیت به‌روز شد");
        }
    }
}
