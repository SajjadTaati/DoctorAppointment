using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Application.DTOs.Admin
{
    public record StatsDto(int Total, int TodayCount, int Pending, int Confirmed);
}
