using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Domain.Entities
{
    public class Slide
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;
        public string? Subtitle { get; set; }
        public string ImageUrl { get; set; } = default!;
        public int Order { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
