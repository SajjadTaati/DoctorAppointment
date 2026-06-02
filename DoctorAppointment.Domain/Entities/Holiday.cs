using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Domain.Entities
{
    public class Holiday
    {
        public int Id { get; set; }
        public DateOnly Date { get; set; }
        public string? Description { get; set; }
    }
}
