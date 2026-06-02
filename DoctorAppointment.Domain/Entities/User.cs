using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Phone { get; set; } = default!;
        public string? Name { get; set; }
        public string? OtpCode { get; set; }
        public DateTime? OtpExpiry { get; set; }

        public ICollection<Appointment> Appointments { get; set; } = [];
    }
}
