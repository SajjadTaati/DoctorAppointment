using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Application.DTOs.Auth
{
    public record AuthResponse(string Token, string Phone, string? Name);
}
