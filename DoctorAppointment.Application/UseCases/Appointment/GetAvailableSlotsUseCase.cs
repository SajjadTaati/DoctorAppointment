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

    public class GetAvailableSlotsUseCase(
        IAppointmentRepository appointmentRepo,
        IWorkingHourRepository workingHourRepo,
        IHolidayRepository holidayRepo)
    {
        public async Task<Result<List<AvailableSlotDto>>> ExecuteAsync(DateOnly date)
        {
            if (date.DayOfWeek == DayOfWeek.Friday)
                return Result<List<AvailableSlotDto>>.Failure("جمعه تعطیل است");

            if (date < DateOnly.FromDateTime(DateTime.Today))
                return Result<List<AvailableSlotDto>>.Failure("تاریخ گذشته");

            if (await holidayRepo.IsHolidayAsync(date))
                return Result<List<AvailableSlotDto>>.Failure("این روز تعطیل است");

            var workingHour = (await workingHourRepo.GetAllAsync())
                .FirstOrDefault(w => w.DayOfWeek == date.DayOfWeek && w.IsActive);

            if (workingHour is null)
                return Result<List<AvailableSlotDto>>.Failure("این روز ساعت کاری ندارد");

            var booked = (await appointmentRepo.GetByDateAsync(date))
                .Select(a => a.TimeSlot)
                .ToHashSet();

            var slots = new List<AvailableSlotDto>();
            var current = workingHour.StartTime;

            while (current + TimeSpan.FromMinutes(workingHour.SlotDurationMinutes) <= workingHour.EndTime)
            {
                if (!booked.Contains(current)) slots.Add(new AvailableSlotDto(current, current.ToString(@"hh\:mm")));
                current += TimeSpan.FromMinutes(workingHour.SlotDurationMinutes);
            }

            return Result<List<AvailableSlotDto>>.Success(slots);
        }
    }
}
