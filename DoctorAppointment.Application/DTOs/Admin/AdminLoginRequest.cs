using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Application.DTOs.Admin
{
    public record AdminLoginRequest(string Username, string Password);

}
