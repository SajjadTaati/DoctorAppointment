using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Application.DTOs.Appointment
{
    public record AppointmentDto(
       int Id,
       DateTime Date,
       TimeSpan TimeSlot,
       string Status,
       string? UserPhone,
       string? UserName,
       DateTime CreatedAt
   );
}
