using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Domain.Services
{
    public interface IJwtService
    {
        string GenerateUserToken(int userId, string phone);
        string GenerateAdminToken(int adminId, string username);
    }
}
