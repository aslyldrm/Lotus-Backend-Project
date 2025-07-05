using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string DoctorId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Status { get; set; } // Örn: "Booked", "Available"
        public User User { get; set; }
        public Doctor Doctor { get; set; }
    }
}
